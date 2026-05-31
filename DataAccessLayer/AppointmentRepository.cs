using Dapper;
using HospitalManagementSystem.Data.Enums;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class AppointmentRepository(IConfiguration configuration, ILogger<AppointmentRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
          ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        // ==================== EXISTING METHODS ====================

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
                a.TokenNumber,
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
                             WHERE a.IsDeleted = 0";

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

                const string sql = @"
            SELECT
                a.Id,
                a.AppointmentDate,
                a.Reason,
                a.Status,
                a.PatientId,
                a.TokenNumber,
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
                             WHERE a.PatientId = @PatientId AND a.IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
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

                if (currentUser.IsInRole("Patient"))
                {
                    if (appointment.DoctorId <= 0)
                    {
                        return ApiResponse<bool>.ErrorResponse(
                            "Doctor is required",
                            new List<string> { "Patients must select a doctor when booking an appointment." });
                    }

                    const string getPatientSql = @"SELECT Id FROM dbo.Patients WHERE UserId = @UserId AND IsDeleted = 0";
                    patientId = await db.ExecuteScalarAsync<int?>(getPatientSql, new { UserId = userId });

                    if (patientId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse("Patient profile not found", new List<string> { "No active patient record found for this user." });
                    }

                    const string getDoctorSql = @"SELECT Id FROM dbo.Doctors WHERE UserId = @DoctorUserId AND IsDeleted = 0";
                    doctorId = await db.ExecuteScalarAsync<int?>(getDoctorSql, new { DoctorUserId = appointment.DoctorId });

                    if (doctorId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse("Doctor not found", new List<string> { "The selected doctor does not exist or is inactive." });
                    }
                }
                else if (currentUser.IsInRole("Doctor"))
                {
                    if (appointment.PatientId == null || appointment.PatientId <= 0)
                    {
                        return ApiResponse<bool>.ErrorResponse("Patient is required", new List<string> { "Doctors must select a patient when creating an appointment." });
                    }

                    const string getDoctorSql = @"SELECT Id FROM dbo.Doctors WHERE UserId = @UserId AND IsDeleted = 0";
                    doctorId = await db.ExecuteScalarAsync<int?>(getDoctorSql, new { UserId = userId });

                    if (doctorId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse("Doctor profile not found", new List<string> { "No active doctor record found for this user." });
                    }

                    const string getPatientSql = @"SELECT Id FROM dbo.Patients WHERE UserId = @PatientUserId AND IsDeleted = 0";
                    patientId = await db.ExecuteScalarAsync<int?>(getPatientSql, new { PatientUserId = appointment.PatientId });

                    if (patientId == null)
                    {
                        return ApiResponse<bool>.ErrorResponse("Patient not found", new List<string> { "The selected patient does not exist or is inactive." });
                    }
                }
                else
                {
                    return ApiResponse<bool>.ErrorResponse("Access denied", new List<string> { "Only Patients and Doctors can create appointments." });
                }

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
                return ApiResponse<bool>.ErrorResponse("An error occurred while creating the appointment.", new List<string> { ex.Message });
            }
        }

        // ==================== NEW TOKEN / QUEUE METHODS ====================

        public async Task<ApiResponse<string>> GenerateAppointmentToken(int appointmentId)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                await db.OpenAsync();

                // Get DoctorId only (ignore AppointmentDate for token generation)
                const string getInfoSql = @"
            SELECT DoctorId 
            FROM Appointments 
            WHERE Id = @AppointmentId AND IsDeleted = 0";

                int doctorId = await db.ExecuteScalarAsync<int>(getInfoSql, new { AppointmentId = appointmentId });

                if (doctorId == 0)
                    return ApiResponse<string>.ErrorResponse("Appointment not found.");

                DateTime today = DateTime.Today;   // ← Always use today's date

                // Get last token for this doctor TODAY
                const string lastTokenSql = @"
            SELECT TOP 1 TokenNumber
            FROM Appointments
            WHERE DoctorId = @DoctorId
              AND TokenDate = @Today
              AND TokenNumber IS NOT NULL
            ORDER BY TokenNumber DESC";

                string lastToken = await db.ExecuteScalarAsync<string>(lastTokenSql, new
                {
                    DoctorId = doctorId,
                    Today = today
                });

                int nextNumber = 1;
                if (!string.IsNullOrEmpty(lastToken))
                {
                    var match = Regex.Match(lastToken, @"\d+");
                    if (match.Success && int.TryParse(match.Value, out int parsed))
                        nextNumber = parsed + 1;
                }

                string newToken = $"T-{nextNumber:D3}"; // T-001, T-002, ...

                // Update appointment with token for TODAY
                const string updateSql = @"
            UPDATE Appointments
            SET TokenNumber = @TokenNumber,
                TokenDate = @TokenDate,
                QueueStatus = 'Waiting'
            WHERE Id = @AppointmentId";

                await db.ExecuteAsync(updateSql, new
                {
                    TokenNumber = newToken,
                    TokenDate = today,
                    AppointmentId = appointmentId
                });

                return ApiResponse<string>.SuccessResponse(newToken, $"Token {newToken} generated successfully for today.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generating token for appointment {AppointmentId}", appointmentId);
                return ApiResponse<string>.ErrorResponse("Failed to generate appointment token.", new List<string> { ex.Message });
            }
        }
        public async Task<ApiResponse<IEnumerable<AppointmentDto>>> GetTodayQueue(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int userIdInt))
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse("Invalid User ID.");
                }

                using IDbConnection db = new SqlConnection(_connectionString);

                // Step 1: Convert UserId to internal DoctorId
                const string getDoctorIdSql = @"
            SELECT Id 
            FROM dbo.Doctors 
            WHERE UserId = @UserId AND IsDeleted = 0";

                int? doctorId = await db.ExecuteScalarAsync<int?>(getDoctorIdSql, new { UserId = userIdInt });

                if (doctorId == null)
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(
                        new List<AppointmentDto>(), "Doctor profile not found.");
                }

                // FIXED QUERY - Use TokenDate instead of AppointmentDate
                const string sql = @"
            SELECT
                a.Id,
                a.TokenNumber,
                a.AppointmentDate,
                a.Reason,
                a.Status,
                a.QueueStatus,
                a.PatientId,
                (up.FirstName + ' ' + up.LastName) AS PatientName,
                up.PhoneNumber AS PatientPhone,
                a.DoctorId,
                (ud.FirstName + ' ' + ud.LastName) AS DoctorName
            FROM Appointments a
            INNER JOIN Patients p ON a.PatientId = p.Id
            INNER JOIN Doctors d ON a.DoctorId = d.Id
            INNER JOIN AspNetUsers up ON p.UserId = up.Id
            INNER JOIN AspNetUsers ud ON d.UserId = ud.Id
            WHERE a.DoctorId = @DoctorId
              AND a.TokenNumber IS NOT NULL
              AND CAST(a.TokenDate AS DATE) = CAST(GETDATE() AS DATE)
              AND a.IsDeleted = 0
            ORDER BY a.TokenNumber";

                var queue = await db.QueryAsync<AppointmentDto>(sql, new { DoctorId = doctorId.Value });

                if (queue == null || !queue.Any())
                {
                    return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(
                        new List<AppointmentDto>(),
                        "No appointments in today's queue.");
                }

                return ApiResponse<IEnumerable<AppointmentDto>>.SuccessResponse(queue, "Today's queue retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching today's queue for UserId: {UserId}", userId);
                return ApiResponse<IEnumerable<AppointmentDto>>.ErrorResponse(
                    "Failed to retrieve today's queue.",
                    new List<string> { ex.Message });
            }
        }
        public async Task<ApiResponse<bool>> UpdateQueueStatus(int appointmentId, string queueStatus)
        {
            try
            {
                const string sql = @"UPDATE Appointments 
                                     SET QueueStatus = @QueueStatus 
                                     WHERE Id = @AppointmentId AND IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
                var result = await db.ExecuteAsync(sql, new
                {
                    AppointmentId = appointmentId,
                    QueueStatus = queueStatus
                });

                if (result > 0)
                {
                    return ApiResponse<bool>.SuccessResponse(true, $"Queue status updated to {queueStatus}.");
                }
                else
                {
                    return ApiResponse<bool>.ErrorResponse("Failed to update queue status.", new List<string> { "Appointment not found or already deleted." });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating queue status for appointment {AppointmentId}", appointmentId);
                return ApiResponse<bool>.ErrorResponse("Failed to update queue status.", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> CancelAppointment(int appointmentId)
        {
            try
            {
                const string sql = @"UPDATE Appointments 
                             SET Status = @Status, QueueStatus = 'Cancelled'
                             WHERE Id = @AppointmentId AND IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
                var result = await db.ExecuteAsync(sql, new
                {
                    AppointmentId = appointmentId,
                    Status = (int)AppointmentStatus.Cancelled  // stores 5, not "Cancelled"
                });

                return result > 0
                    ? ApiResponse<bool>.SuccessResponse(true, "Appointment cancelled successfully.")
                    : ApiResponse<bool>.ErrorResponse("Failed to cancel appointment.", new List<string> { "No rows affected." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error cancelling appointment {AppointmentId}", appointmentId);
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
                                         Status = @Status
                                     WHERE Id = @AppointmentId AND IsDeleted = 0";

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