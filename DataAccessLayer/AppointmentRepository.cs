using Dapper;
using HospitalManagementSystem.Data.Enums;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class AppointmentRepository(IConfiguration configuration, ILogger<AppointmentRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
          ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        // Update the method signature
        public async Task<ApiResponse<IEnumerable<AppointmentDto>>> GetAllAppointments()
        {
            try
            {
                const string sql = @"SELECT 
                                a.Id,
                                a.AppointmentDate, 
                                a.Reason, 
                                a.Status, 
                                a.PatientId, 
                                (up.FirstName + ' ' + up.LastName) AS PatientName, 
                                up.Email AS PatientEmail, 
                                up.PhoneNumber AS PatientPhone, 
                                a.DoctorId, 
                                (ud.FirstName + ' ' + ud.LastName) AS DoctorName
                             FROM Appointments a
                             INNER JOIN Patients p ON a.PatientId = p.Id
                             INNER JOIN Doctors d ON a.DoctorId = d.Id
                             JOIN AspNetUsers uP ON p.UserId = uP.Id
                                JOIN AspNetUsers uD ON d.UserId = uD.Id
                             WHERE a.IsDeleted = 0"; // Filter applied here
                using IDbConnection db = new SqlConnection(_connectionString);
                var appointments = await db.QueryAsync<AppointmentDto>(sql);
                if (appointments == null || !appointments.Any())
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(new List<AppointmentDto>(), "No appointments found.");
                }
                return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(appointments, "Appointments retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all appointments.");
                return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse("Failed to retrieve appointments.", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<AppointmentDto>>> GetAppointments(string userId, bool isDoctor, bool isPatient)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse("Database configuration is missing.", new List<string>());
            }

            using IDbConnection db = new SqlConnection(_connectionString);

            try
            {
                int? internalId = null;
                string lookupSql = "";

                // 1. Resolve the internal ID based on the role
                if (isPatient)
                {
                    lookupSql = "SELECT Id FROM dbo.Patients WHERE UserId = @UserId AND IsDeleted = 0";
                }
                else if (isDoctor)
                {
                    lookupSql = "SELECT Id FROM dbo.Doctors WHERE UserId = @UserId AND IsDeleted = 0";
                }

                if (!string.IsNullOrEmpty(lookupSql))
                {
                    internalId = await db.ExecuteScalarAsync<int?>(lookupSql, new { UserId = userId });
                }

                if (internalId == null)
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(new List<AppointmentDto>(), "No profile found for this user.");
                }

                // 2. Query Appointments joining through Patients/Doctors to AspNetUsers
                const string sql = @"
            SELECT 
                a.Id,
                a.AppointmentDate,
                a.Reason,
                a.Status,
                a.PatientId,
                (ISNULL(uP.FirstName, '') + ' ' + ISNULL(uP.LastName, '')) AS PatientName,
                uP.Email AS PatientEmail,
                a.DoctorId,
                (ISNULL(uD.FirstName, '') + ' ' + ISNULL(uD.LastName, '')) AS DoctorName
            FROM dbo.Appointments a
            INNER JOIN dbo.Patients p ON a.PatientId = p.Id
            INNER JOIN dbo.AspNetUsers uP ON p.UserId = uP.Id
            INNER JOIN dbo.Doctors d ON a.DoctorId = d.Id
            INNER JOIN dbo.AspNetUsers uD ON d.UserId = uD.Id
            WHERE a.IsDeleted = 0
              AND (
                  (@IsDoctor = 1 AND a.DoctorId = @InternalId)
               OR (@IsPatient = 1 AND a.PatientId = @InternalId)
              )
            ORDER BY a.AppointmentDate DESC";

                var parameters = new
                {
                    InternalId = internalId,
                    IsDoctor = isDoctor ? 1 : 0,
                    IsPatient = isPatient ? 1 : 0
                };

                var appointments = await db.QueryAsync<AppointmentDto>(sql, parameters);
                var appointmentList = appointments?.ToList() ?? new List<AppointmentDto>();

                return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(
                    appointmentList,
                    appointmentList.Any() ? "Appointments retrieved successfully." : "No appointments found.");
            }
            catch (Exception ex)
            {
                // logger?.LogError(ex, "Error fetching appointments...");
                return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse(
                    "Failed to retrieve appointments.",
                    new List<string> { ex.Message });
            }
        }
        public async Task<ApiResponse<IEnumerable<AppointmentDto>>> GetAppointmentsForPatient(string patientId)
        {
            try
            {
                const string sql = @"SELECT 
                                a.AppointmentDate, 
                                a.Reason, 
                                a.Status, 
                                a.PatientId, 
                                (p.FirstName + ' ' + p.LastName) AS PatientName, 
                                p.Email AS PatientEmail, 
                                p.PhoneNumber AS PatientPhone, 
                                a.DoctorId, 
                                (d.FirstName + ' ' + d.LastName) AS DoctorName
                             FROM Appointments a
                             INNER JOIN AspNetUsers p ON a.PatientId = p.Id
                             INNER JOIN AspNetUsers d ON a.DoctorId = d.Id
                             WHERE a.PatientId = @PatientId AND a.IsDeleted = 0"; // Filter applied here
                using IDbConnection db = new SqlConnection(_connectionString);
                // Pass the patientId as a parameter to prevent SQL injection
                var appointments = await db.QueryAsync<AppointmentDto>(sql, new { PatientId = patientId });
                if (appointments == null || !appointments.Any())
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(new List<AppointmentDto>(), "No appointments found.");
                }
                return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(appointments, "Appointments retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching appointments for Patient: {PatientId}", patientId);
                return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse("Failed to retrieve appointments.", new List<string> { ex.Message });
            }

        }
        public async Task<ApiResponse<bool>> CreateAppointment(int userId, CreateAppointmentRequest appointment, ClaimsPrincipal currentUser)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);

                int? patientId = null;
                int? doctorId = null;

                // ==================== PATIENT ROLE ====================
                if (currentUser.IsInRole("Patient"))
                {
                    if (appointment.DoctorId <=0)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Doctor is required",
                            new List<string> { "Patients must select a doctor when booking an appointment." });
                    }

                    // Get Patient's real Id from Patients table
                    const string getPatientSql = @"
                SELECT Id 
                FROM dbo.Patients 
                WHERE UserId = @UserId AND IsDeleted = 0";

                    patientId = await db.ExecuteScalarAsync<int?>(getPatientSql, new { UserId = userId });

                    if (patientId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Patient profile not found",
                            new List<string> { "No active patient record found for this user." });
                    }

                    // Get Doctor's real Id from Doctors table (appointment.DoctorId is UserId)
                    const string getDoctorSql = @"
                SELECT Id 
                FROM dbo.Doctors 
                WHERE UserId = @DoctorUserId AND IsDeleted = 0";

                    doctorId = await db.ExecuteScalarAsync<int?>(getDoctorSql, new { DoctorUserId = appointment.DoctorId });

                    if (doctorId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Doctor not found",
                            new List<string> { "The selected doctor does not exist or is inactive." });
                    }
                }
                // ==================== DOCTOR ROLE ====================
                else if (currentUser.IsInRole("Doctor"))
                {
                    if (appointment.PatientId == null || appointment.PatientId <= 0)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Patient is required",
                            new List<string> { "Doctors must select a patient when creating an appointment." });
                    }

                    // Get Doctor's real Id
                    const string getDoctorSql = @"
                SELECT Id 
                FROM dbo.Doctors 
                WHERE UserId = @UserId AND IsDeleted = 0";

                    doctorId = await db.ExecuteScalarAsync<int?>(getDoctorSql, new { UserId = userId });

                    if (doctorId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Doctor profile not found",
                            new List<string> { "No active doctor record found for this user." });
                    }

                    // Get Patient's real Id (appointment.PatientId is UserId from frontend)
                    const string getPatientSql = @"
                SELECT Id 
                FROM dbo.Patients 
                WHERE UserId = @PatientUserId AND IsDeleted = 0";

                    patientId = await db.ExecuteScalarAsync<int?>(getPatientSql, new { PatientUserId = appointment.PatientId });

                    if (patientId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Patient not found",
                            new List<string> { "The selected patient does not exist or is inactive." });
                    }
                }
                else
                {
                    return ApiResponse<bool>.ErrorResponse("Access denied",
                        new List<string> { "Only Patients and Doctors can create appointments." });
                }

                // ==================== INSERT APPOINTMENT ====================
                const string insertSql = @"
            INSERT INTO dbo.Appointments 
                (DoctorId, PatientId, AppointmentDate, Reason, Status, IsDeleted)
            VALUES 
                (@DoctorId, @PatientId, @AppointmentDate, @Reason, @Status, 0)";

                int rowsAffected = await db.ExecuteAsync(insertSql, new
                {
                    DoctorId = doctorId.Value,
                    PatientId = patientId.Value,
                    AppointmentDate = appointment.AppointmentDate,
                    Reason = appointment.Reason?.Trim() ?? "",
                    Status = (int)AppointmentStatus.Pending,
                });

                if (rowsAffected > 0)
                {
                    return ApiResponse<bool>.SuccessResponse(true, "Appointment created successfully.");
                }

                return ApiResponse<bool>.ErrorResponse("Failed to create appointment.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating appointment for UserId: {UserId}", userId);
                return ApiResponse<bool>.ErrorResponse("An error occurred while creating the appointment.",
                    new List<string> { ex.Message });
            }
        }
        public async Task<ApiResponse<bool>> CancelAppointment(int appointmentId)
        {
            try
            {
                const string sql = @"UPDATE Appointments SET Status = 'Cancelled' WHERE Id = @AppointmentId AND IsDeleted = 0"; // Ensure we only update non-deleted appointments
                using IDbConnection db = new SqlConnection(_connectionString);
                var result = await db.ExecuteAsync(sql, new { AppointmentId = appointmentId });
                if (result > 0)
                {
                    return ApiResponse<bool>.SuccessResponse(true, "Appointment cancelled successfully.");
                }
                else
                {
                    return ApiResponse<bool>.ErrorResponse("Failed to cancel appointment.", new List<string> { "No rows affected or appointment already cancelled/deleted." });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error cancelling appointment with ID: {AppointmentId}", appointmentId);
                return ApiResponse<bool>.ErrorResponse("Failed to cancel appointment.", new List<string> { ex.Message });
            }
        }
        public async Task<ApiResponse<string>> UpdateAppointment(int appointmentId, UpdateAppointmentRequest request)
        {
            try
            {
                const string sql = @"UPDATE Appointments 
                                     SET AppointmentDate = @AppointmentDate, 
                                         Reason = @Reason, 
                                         Status = 5 
                                     WHERE Id = @AppointmentId AND IsDeleted = 0"; // Ensure we only update non-deleted appointments
                using IDbConnection db = new SqlConnection(_connectionString);
                var result = await db.ExecuteAsync(sql, new
                {
                    AppointmentId = appointmentId,
                    AppointmentDate = request.AppointmentDate,
                    Reason = request.Reason,
                    Status = request.Status
                });
                if (result > 0)
                {
                    return ApiResponse<string>.SuccessResponse("Appointment updated successfully.");
                }
                else
                {
                    return ApiResponse<string>.ErrorResponse("Failed to update appointment.", new List<string> { "No rows affected or appointment may be cancelled/deleted." });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating appointment with ID: {AppointmentId}", appointmentId);
                return ApiResponse<string>.ErrorResponse("Failed to update appointment.", new List<string> { ex.Message });
            }
        }
    }
}