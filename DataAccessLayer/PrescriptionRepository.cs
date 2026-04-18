using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class PrescriptionRepository(IConfiguration configuration, ILogger<PrescriptionRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        // Get My Prescriptions (for Doctor and Patient)
        public async Task<ApiResponse<IEnumerable<PrescriptionDto>>> GetMyPrescriptions(string userId, bool isDoctor, bool isPatient)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);

                int? internalId = null;

                if (isPatient)
                {
                    internalId = await db.ExecuteScalarAsync<int?>(
                        "SELECT Id FROM Patients WHERE UserId = @UserId AND IsDeleted = 0",
                        new { UserId = userId });
                }
                else if (isDoctor)
                {
                    internalId = await db.ExecuteScalarAsync<int?>(
                        "SELECT Id FROM Doctors WHERE UserId = @UserId AND IsDeleted = 0",
                        new { UserId = userId });
                }

                if (internalId == null)
                {
                    return ApiResponse<IEnumerable<PrescriptionDto>>.SuccessResponse(new List<PrescriptionDto>(), "No profile found.");
                }

                const string sql = @"
            SELECT 
                p.Id,
                p.PrescriptionDate,
                p.Instructions,
                p.PatientId,
                (up.FirstName + ' ' + up.LastName) AS PatientName,
                up.Email AS PatientEmail,
                p.DoctorId,
                (ud.FirstName + ' ' + ud.LastName) AS DoctorName,
                pi.Id AS PrescriptionItemId, -- This is our split point
                pi.MedicineId,
                m.Name AS MedicineName,
                pi.Quantity,
                pi.Dosage,
                pi.PriceAtIssue
            FROM dbo.Prescriptions p
            INNER JOIN dbo.Patients pat ON p.PatientId = pat.Id
            INNER JOIN dbo.Doctors doc ON p.DoctorId = doc.Id
            JOIN dbo.AspNetUsers up ON pat.UserId = up.Id
            JOIN dbo.AspNetUsers ud ON doc.UserId = ud.Id
            LEFT JOIN dbo.PrescriptionItems pi ON p.Id = pi.PrescriptionId
            LEFT JOIN dbo.Medicines m ON pi.MedicineId = m.Id
            WHERE p.IsDeleted = 0
              AND (
                  (@IsDoctor = 1 AND p.DoctorId = @InternalId)
               OR (@IsPatient = 1 AND p.PatientId = @InternalId)
              )
            ORDER BY p.PrescriptionDate DESC";

                var prescriptionDict = new Dictionary<int, PrescriptionDto>();

                await db.QueryAsync<PrescriptionDto, PrescriptionItemDto, PrescriptionDto>(
                    sql,
                    (prescription, item) =>
                    {
                        if (!prescriptionDict.TryGetValue(prescription.Id, out var existing))
                        {
                            existing = prescription;
                            existing.Items = new List<PrescriptionItemDto>();
                            prescriptionDict.Add(existing.Id, existing);
                        }

                        // Logic: If the LEFT JOIN found an item, it won't be null
                        // We check MedicineId > 0 because if no item exists, 
                        // Dapper might return an object with default (0) values.
                        if (item != null && item.MedicineId > 0)
                        {
                            // If you renamed pi.Id to PrescriptionItemId in SQL, 
                            // ensure your PrescriptionItemDto has that property 
                            // OR map it back to .Id like this:
                            existing.Items.Add(item);
                        }

                        return existing;
                    },
                    new
                    {
                        InternalId = internalId,
                        IsDoctor = isDoctor ? 1 : 0,
                        IsPatient = isPatient ? 1 : 0
                    },
                    splitOn: "PrescriptionItemId"); // Match the alias in the SQL

                var prescriptions = prescriptionDict.Values.ToList();

                return ApiResponse<IEnumerable<PrescriptionDto>>.SuccessResponse(
                    prescriptions,
                    prescriptions.Any() ? "Prescriptions retrieved successfully." : "No prescriptions found.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<PrescriptionDto>>.ErrorResponse("Failed to retrieve prescriptions.", new List<string> { ex.Message });
            }
        }
        // Get All Prescriptions (Admin only)
        // Get Single Prescription Details by ID (for Doctor View)
        public async Task<ApiResponse<PrescriptionDto>> GetPrescriptionDetails(int prescriptionId)
        {
            try
            {
                const string sql = @"
            SELECT
                p.Id,
                p.PrescriptionDate,
                p.Instructions,
                p.PatientId,
                (up.FirstName + ' ' + up.LastName) AS PatientName,
                up.Email AS PatientEmail,
                ISNULL(up.PhoneNumber, '') AS PatientPhone,
                p.DoctorId,
                (ud.FirstName + ' ' + ud.LastName) AS DoctorName,
                pi.Id AS ItemId,
                pi.MedicineId,
                m.Name AS MedicineName,
                pi.Quantity,
                pi.Dosage,
                pi.PriceAtIssue
            FROM dbo.Prescriptions p
            INNER JOIN dbo.Patients pat ON p.PatientId = pat.Id
            INNER JOIN dbo.Doctors doc ON p.DoctorId = doc.Id
            JOIN dbo.AspNetUsers up ON pat.UserId = up.Id
            JOIN dbo.AspNetUsers ud ON doc.UserId = ud.Id
            LEFT JOIN dbo.PrescriptionItems pi ON p.Id = pi.PrescriptionId
            LEFT JOIN dbo.Medicines m ON pi.MedicineId = m.Id
            WHERE p.IsDeleted = 0 
              AND p.Id = @PrescriptionId
            ORDER BY pi.Id;";

                using IDbConnection db = new SqlConnection(_connectionString);

                var prescriptionDict = new Dictionary<int, PrescriptionDto>();

                await db.QueryAsync<PrescriptionDto, PrescriptionItemDto, PrescriptionDto>(
                    sql,
                    (prescription, item) =>
                    {
                        if (!prescriptionDict.TryGetValue(prescription.Id, out var existing))
                        {
                            existing = prescription;
                            existing.Items = new List<PrescriptionItemDto>();
                            prescriptionDict.Add(existing.Id, existing);
                        }

                        // Only add item if it exists (MedicineId > 0)
                        if (item != null && item.MedicineId > 0)
                        {
                            existing.Items.Add(item);
                        }

                        return existing;
                    },
                    new { PrescriptionId = prescriptionId },
                    splitOn: "ItemId"
                );

                var prescription = prescriptionDict.Values.FirstOrDefault();

                if (prescription == null)
                {
                    return ApiResponse<PrescriptionDto>.ErrorResponse("Prescription not found.");
                }

                return ApiResponse<PrescriptionDto>.SuccessResponse(
                    prescription,
                    "Prescription details retrieved successfully."
                );
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching prescription details for ID: {PrescriptionId}", prescriptionId);
                return ApiResponse<PrescriptionDto>.ErrorResponse(
                    "Failed to retrieve prescription details.",
                    new List<string> { ex.Message }
                );
            }
        }
        public async Task<ApiResponse<IEnumerable<PrescriptionDto>>> GetAllPrescriptions()
        {
            try
            {
                const string sql = @"
                    SELECT 
                        p.Id,
                        p.PrescriptionDate,
                        p.Instructions,
                        p.PatientId,
                        (up.FirstName + ' ' + up.LastName) AS PatientName,
                        up.Email AS PatientEmail,
                        p.DoctorId,
                        (ud.FirstName + ' ' + ud.LastName) AS DoctorName,
                        pi.Id AS ItemId,
                        pi.MedicineId,
                        m.Name AS MedicineName,
                        pi.Quantity,
                        pi.Dosage,
                        pi.PriceAtIssue
                    FROM dbo.Prescriptions p
                    INNER JOIN dbo.Patients pat ON p.PatientId = pat.Id
                    INNER JOIN dbo.Doctors doc ON p.DoctorId = doc.Id
                    JOIN dbo.AspNetUsers up ON pat.UserId = up.Id
                    JOIN dbo.AspNetUsers ud ON doc.UserId = ud.Id
                    LEFT JOIN dbo.PrescriptionItems pi ON p.Id = pi.PrescriptionId
                    LEFT JOIN dbo.Medicines m ON pi.MedicineId = m.Id
                    WHERE p.IsDeleted = 0
                    ORDER BY p.PrescriptionDate DESC";

                using IDbConnection db = new SqlConnection(_connectionString);
                var prescriptionDict = new Dictionary<int, PrescriptionDto>();

                await db.QueryAsync<PrescriptionDto, PrescriptionItemDto, PrescriptionDto>(
                    sql,
                    (prescription, item) =>
                    {
                        if (!prescriptionDict.TryGetValue(prescription.Id, out var existing))
                        {
                            existing = prescription;
                            existing.Items = new List<PrescriptionItemDto>();
                            prescriptionDict.Add(existing.Id, existing);
                        }
                        if (item != null && item.Id > 0)
                            existing.Items.Add(item);

                        return existing;
                    },
                    splitOn: "ItemId");

                var prescriptions = prescriptionDict.Values.ToList();

                return ApiResponse<IEnumerable<PrescriptionDto>>.SuccessResponse(
                    prescriptions,
                    prescriptions.Any() ? "Prescriptions retrieved successfully." : "No prescriptions found.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all prescriptions.");
                return ApiResponse<IEnumerable<PrescriptionDto>>.ErrorResponse("Failed to retrieve prescriptions.", new List<string> { ex.Message });
            }
        }

        // Create Prescription + Items
        public async Task<ApiResponse<int>> CreatePrescription(int userId, CreatePrescriptionRequest request)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            db.Open();
            using var transaction = db.BeginTransaction();

            try
            {
                // 1. Get Patient & Doctor IDs
                const string getPatientSql = "SELECT Id FROM dbo.Patients WHERE UserId = @UserId AND IsDeleted = 0";
                int? patientInternalId = await db.ExecuteScalarAsync<int?>(getPatientSql, new { UserId = request.PatientId }, transaction);

                const string getDoctorSql = "SELECT Id FROM dbo.Doctors WHERE UserId = @UserId AND IsDeleted = 0";
                int? doctorInternalId = await db.ExecuteScalarAsync<int?>(getDoctorSql, new { UserId = userId }, transaction);

                if (patientInternalId == null || doctorInternalId == null)
                    return ApiResponse<int>.ErrorResponse("Patient or Doctor profile not found.");

                // 2. Fetch the current AppointmentId (Since it's not in the DTO)
                // We look for the latest non-deleted appointment for this patient/doctor pair
                const string getAppointmentSql = @"
            SELECT TOP 1 Id FROM dbo.Appointments 
            WHERE PatientId = @PatientId AND DoctorId = @DoctorId AND IsDeleted = 0 
            ORDER BY AppointmentDate DESC";

                int? appointmentId = await db.ExecuteScalarAsync<int?>(getAppointmentSql,
                    new { PatientId = patientInternalId, DoctorId = doctorInternalId }, transaction);

                // 3. Insert into Prescriptions
                const string insertPrescriptionSql = @"
            INSERT INTO dbo.Prescriptions (PatientId, DoctorId, PrescriptionDate, Instructions, IsDeleted)
            VALUES (@PatientId, @DoctorId, @PrescriptionDate, @Instructions, 0);
            SELECT CAST(SCOPE_IDENTITY() as int);";

                int prescriptionId = await db.ExecuteScalarAsync<int>(insertPrescriptionSql, new
                {
                    PatientId = patientInternalId.Value,
                    DoctorId = doctorInternalId.Value,
                    request.PrescriptionDate,
                    Instructions = request.Instructions ?? ""
                }, transaction);

                // 4. Insert Items & Calculate Total
                decimal totalMedicineCost = 0;
                if (request.Items != null && request.Items.Any())
                {
                    const string insertItemSql = @"
                INSERT INTO dbo.PrescriptionItems (PrescriptionId, MedicineId, Quantity, Dosage, PriceAtIssue, IsDeleted)
                VALUES (@PrescriptionId, @MedicineId, @Quantity, @Dosage, 
                       (SELECT UnitPrice FROM Medicines WHERE Id = @MedicineId), 0);
                SELECT UnitPrice FROM Medicines WHERE Id = @MedicineId;";

                    foreach (var item in request.Items)
                    {
                        decimal unitPrice = await db.ExecuteScalarAsync<decimal>(insertItemSql, new
                        {
                            PrescriptionId = prescriptionId,
                            item.MedicineId,
                            item.Quantity,
                            item.Dosage
                        }, transaction);

                        totalMedicineCost += (unitPrice * item.Quantity);
                    }
                }

                // 5. Generate Bill with Pakistan Timezone
                decimal consultationFee = 1000; // Adjust based on your hospital policy
                decimal taxAmount = (totalMedicineCost + consultationFee) * 0.05m; // 5% Tax
                decimal grandTotal = totalMedicineCost + consultationFee + taxAmount;

                // Handling Pakistan Time (UTC+5)
                DateTime pakistanTime = DateTime.UtcNow.AddHours(5);

                const string insertBillSql = @"
            INSERT INTO [HMS].[dbo].[Bills] 
                ([TotalAmount], [Tax], [BillingDate], [IsPaid], [AppointmentId], [IsDeleted])
            VALUES 
                (@TotalAmount, @Tax, @BillingDate, 0, @AppointmentId, 0);";

                await db.ExecuteAsync(insertBillSql, new
                {
                    TotalAmount = grandTotal,
                    Tax = taxAmount,
                    BillingDate = pakistanTime,
                    AppointmentId = appointmentId // Will be NULL if no appointment was found
                }, transaction);

                transaction.Commit();
                return ApiResponse<int>.SuccessResponse(prescriptionId, "Prescription and Bill created successfully.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                logger.LogError(ex, "Error creating prescription/bill for UserId: {UserId}", userId);
                return ApiResponse<int>.ErrorResponse("Failed to save prescription. Transaction rolled back.", new List<string> { ex.Message });
            }
        }
    }
}