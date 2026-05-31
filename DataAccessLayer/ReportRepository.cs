using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class ReportRepository(IConfiguration configuration, ILogger<ReportRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        // ==================== ADMIN REPORT ====================

        public async Task<ApiResponse<AdminReportDto>> GetAdminReport()
        {
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var report = new AdminReportDto();

                // ── Appointment Stats ──────────────────────────────────────────
                const string appointmentStatsSql = @"
                    SELECT
                        COUNT(*) AS TotalAppointments,
                        SUM(CASE WHEN Status = '0' OR Status = 'Pending'        THEN 1 ELSE 0 END) AS PendingAppointments,
                        SUM(CASE WHEN Status = '4' OR Status = 'Completed'      THEN 1 ELSE 0 END) AS CompletedAppointments,
                        SUM(CASE WHEN Status = '5' OR Status = 'Cancelled'      THEN 1 ELSE 0 END) AS CancelledAppointments,
                        SUM(CASE WHEN Status = '1' OR Status = 'Confirmed'      THEN 1 ELSE 0 END) AS ConfirmedAppointments
                    FROM dbo.Appointments
                    WHERE IsDeleted = 0";

                var apptStats = await db.QueryFirstOrDefaultAsync(appointmentStatsSql);
                if (apptStats != null)
                {
                    report.TotalAppointments = (int)(apptStats.TotalAppointments ?? 0);
                    report.PendingAppointments = (int)(apptStats.PendingAppointments ?? 0);
                    report.CompletedAppointments = (int)(apptStats.CompletedAppointments ?? 0);
                    report.CancelledAppointments = (int)(apptStats.CancelledAppointments ?? 0);
                    report.ConfirmedAppointments = (int)(apptStats.ConfirmedAppointments ?? 0);
                }

                // ── Revenue ────────────────────────────────────────────────────
                const string revenueSql = @"
                    SELECT
                        ISNULL(SUM(TotalAmount), 0)                                          AS TotalRevenue,
                        ISNULL(SUM(CASE WHEN IsPaid = 1 THEN TotalAmount ELSE 0 END), 0)    AS PaidRevenue,
                        ISNULL(SUM(CASE WHEN IsPaid = 0 THEN TotalAmount ELSE 0 END), 0)    AS UnpaidRevenue
                    FROM dbo.Bills
                    WHERE IsDeleted = 0";

                var rev = await db.QueryFirstOrDefaultAsync(revenueSql);
                if (rev != null)
                {
                    report.TotalRevenue = (decimal)(rev.TotalRevenue ?? 0);
                    report.PaidRevenue = (decimal)(rev.PaidRevenue ?? 0);
                    report.UnpaidRevenue = (decimal)(rev.UnpaidRevenue ?? 0);
                }

                // ── Revenue by Month (last 12 months) ─────────────────────────
                const string revenueByMonthSql = @"
                    SELECT
                        FORMAT(BillingDate, 'MMM yyyy')  AS Month,
                        ISNULL(SUM(TotalAmount), 0)      AS Amount,
                        COUNT(*)                         AS Count
                    FROM dbo.Bills
                    WHERE IsDeleted = 0
                      AND BillingDate >= DATEADD(MONTH, -11,
                          DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
                    GROUP BY
                        FORMAT(BillingDate, 'MMM yyyy'),
                        YEAR(BillingDate),
                        MONTH(BillingDate)
                    ORDER BY
                        YEAR(BillingDate),
                        MONTH(BillingDate)";

                var revenueByMonth = await db.QueryAsync<RevenueByMonthDto>(revenueByMonthSql);
                report.RevenueByMonth = revenueByMonth.ToList();

                // ── Prescriptions ──────────────────────────────────────────────
                const string prescriptionSql = @"
                    SELECT
                        COUNT(DISTINCT p.Id)        AS TotalPrescriptions,
                        ISNULL(SUM(pi.Quantity), 0) AS TotalMedicinesDispensed
                    FROM dbo.Prescriptions p
                    LEFT JOIN dbo.PrescriptionItems pi ON p.Id = pi.PrescriptionId
                    WHERE p.IsDeleted = 0";

                var presc = await db.QueryFirstOrDefaultAsync(prescriptionSql);
                if (presc != null)
                {
                    report.TotalPrescriptions = (int)(presc.TotalPrescriptions ?? 0);
                    report.TotalMedicinesDispensed = (int)(presc.TotalMedicinesDispensed ?? 0);
                }

                // ── Doctor Performance ─────────────────────────────────────────
                const string doctorPerfSql = @"
                    SELECT
                        (ud.FirstName + ' ' + ud.LastName)  AS DoctorName,
                        COUNT(DISTINCT a.Id)                AS TotalAppointments,
                        SUM(CASE WHEN a.Status = '4' OR a.Status = 'Completed'
                                 THEN 1 ELSE 0 END)         AS CompletedAppointments,
                        COUNT(DISTINCT pr.Id)               AS TotalPrescriptions
                    FROM dbo.Doctors d
                    INNER JOIN dbo.AspNetUsers ud  ON d.UserId    = ud.Id
                    LEFT  JOIN dbo.Appointments a  ON a.DoctorId  = d.Id  AND a.IsDeleted  = 0
                    LEFT  JOIN dbo.Prescriptions pr ON pr.DoctorId = d.Id AND pr.IsDeleted = 0
                    WHERE d.IsDeleted = 0
                    GROUP BY ud.FirstName, ud.LastName
                    ORDER BY TotalAppointments DESC";

                var doctorPerf = await db.QueryAsync<DoctorPerformanceDto>(doctorPerfSql);
                report.DoctorPerformance = doctorPerf.ToList();

                // ── Patient Visits ─────────────────────────────────────────────
                const string patientVisitsSql = @"
                    SELECT
                        (up.FirstName + ' ' + up.LastName)  AS PatientName,
                        up.Email                            AS PatientEmail,
                        MAX(a.AppointmentDate)              AS LastVisit,
                        COUNT(a.Id)                         AS TotalVisits
                    FROM dbo.Patients p
                    INNER JOIN dbo.AspNetUsers  up ON p.UserId    = up.Id
                    INNER JOIN dbo.Appointments a  ON a.PatientId = p.Id AND a.IsDeleted = 0
                    WHERE p.IsDeleted = 0
                    GROUP BY up.FirstName, up.LastName, up.Email
                    ORDER BY LastVisit DESC";

                var visits = await db.QueryAsync<PatientVisitDto>(patientVisitsSql);
                report.RecentPatientVisits = visits.ToList();
                report.UniquePatients = report.RecentPatientVisits.Count;
                report.TotalPatients = report.RecentPatientVisits.Sum(v => v.TotalVisits);

                return ApiResponse<AdminReportDto>.SuccessResponse(report, "Admin report generated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generating admin report.");
                return ApiResponse<AdminReportDto>.ErrorResponse(
                    "Failed to generate report.",
                    new List<string> { ex.Message });
            }
        }

        // ==================== DOCTOR REPORT ====================

        public async Task<ApiResponse<DoctorReportDto>> GetDoctorReport(string userId)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);

                // Convert UserId → internal DoctorId
                int? doctorId = await db.ExecuteScalarAsync<int?>(
                    "SELECT Id FROM dbo.Doctors WHERE UserId = @UserId AND IsDeleted = 0",
                    new { UserId = userId });

                if (doctorId == null)
                    return ApiResponse<DoctorReportDto>.ErrorResponse("Doctor profile not found.");

                var report = new DoctorReportDto();

                // ── Appointment Stats ──────────────────────────────────────────
                const string apptSql = @"
                    SELECT
                        COUNT(*) AS TotalAppointments,
                        SUM(CASE WHEN Status = '0' OR Status = 'Pending'   THEN 1 ELSE 0 END) AS PendingAppointments,
                        SUM(CASE WHEN Status = '4' OR Status = 'Completed' THEN 1 ELSE 0 END) AS CompletedAppointments,
                        SUM(CASE WHEN Status = '5' OR Status = 'Cancelled' THEN 1 ELSE 0 END) AS CancelledAppointments,
                        SUM(CASE WHEN Status = '1' OR Status = 'Confirmed' THEN 1 ELSE 0 END) AS ConfirmedAppointments
                    FROM dbo.Appointments
                    WHERE DoctorId = @DoctorId AND IsDeleted = 0";

                var apptStats = await db.QueryFirstOrDefaultAsync(apptSql, new { DoctorId = doctorId });
                if (apptStats != null)
                {
                    report.TotalAppointments = (int)(apptStats.TotalAppointments ?? 0);
                    report.PendingAppointments = (int)(apptStats.PendingAppointments ?? 0);
                    report.CompletedAppointments = (int)(apptStats.CompletedAppointments ?? 0);
                    report.CancelledAppointments = (int)(apptStats.CancelledAppointments ?? 0);
                    report.ConfirmedAppointments = (int)(apptStats.ConfirmedAppointments ?? 0);
                }

                // ── Prescriptions ──────────────────────────────────────────────
                const string prescSql = @"
                    SELECT
                        COUNT(DISTINCT p.Id)        AS TotalPrescriptions,
                        ISNULL(SUM(pi.Quantity), 0) AS TotalMedicinesDispensed
                    FROM dbo.Prescriptions p
                    LEFT JOIN dbo.PrescriptionItems pi ON p.Id = pi.PrescriptionId
                    WHERE p.DoctorId = @DoctorId AND p.IsDeleted = 0";

                var presc = await db.QueryFirstOrDefaultAsync(prescSql, new { DoctorId = doctorId });
                if (presc != null)
                {
                    report.TotalPrescriptions = (int)(presc.TotalPrescriptions ?? 0);
                    report.TotalMedicinesDispensed = (int)(presc.TotalMedicinesDispensed ?? 0);
                }

                // ── Appointments by Month (last 12 months) ─────────────────────
                const string apptByMonthSql = @"
                    SELECT
                        FORMAT(AppointmentDate, 'MMM yyyy')  AS Month,
                        0                                    AS Amount,
                        COUNT(*)                             AS Count
                    FROM dbo.Appointments
                    WHERE DoctorId = @DoctorId
                      AND IsDeleted = 0
                      AND AppointmentDate >= DATEADD(MONTH, -11,
                          DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
                    GROUP BY
                        FORMAT(AppointmentDate, 'MMM yyyy'),
                        YEAR(AppointmentDate),
                        MONTH(AppointmentDate)
                    ORDER BY
                        YEAR(AppointmentDate),
                        MONTH(AppointmentDate)";

                var byMonth = await db.QueryAsync<RevenueByMonthDto>(apptByMonthSql, new { DoctorId = doctorId });
                report.AppointmentsByMonth = byMonth.ToList();

                // ── Patient Visits ─────────────────────────────────────────────
                const string visitsSql = @"
                    SELECT
                        (up.FirstName + ' ' + up.LastName)  AS PatientName,
                        up.Email                            AS PatientEmail,
                        MAX(a.AppointmentDate)              AS LastVisit,
                        COUNT(a.Id)                         AS TotalVisits
                    FROM dbo.Patients p
                    INNER JOIN dbo.AspNetUsers  up ON p.UserId    = up.Id
                    INNER JOIN dbo.Appointments a  ON a.PatientId = p.Id
                    WHERE a.DoctorId = @DoctorId
                      AND a.IsDeleted = 0
                      AND p.IsDeleted = 0
                    GROUP BY up.FirstName, up.LastName, up.Email
                    ORDER BY LastVisit DESC";

                var visits = await db.QueryAsync<PatientVisitDto>(visitsSql, new { DoctorId = doctorId });
                report.RecentPatientVisits = visits.ToList();
                report.UniquePatients = report.RecentPatientVisits.Count;

                return ApiResponse<DoctorReportDto>.SuccessResponse(report, "Doctor report generated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generating doctor report for userId {UserId}", userId);
                return ApiResponse<DoctorReportDto>.ErrorResponse(
                    "Failed to generate report.",
                    new List<string> { ex.Message });
            }
        }
    }
}