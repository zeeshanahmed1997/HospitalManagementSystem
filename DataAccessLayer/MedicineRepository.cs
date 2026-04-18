using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class MedicineRepository(IConfiguration configuration, ILogger<MedicineRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        // Get All Medicines (with current stock)
        public async Task<ApiResponse<IEnumerable<MedicineDto>>> GetAllMedicines()
        {
            try
            {
                const string sql = @"
                    SELECT 
                        Id,
                        Name,
                        GenericName,
                        Description,
                        UnitPrice,
                        StockQuantity,
                        ExpiryDate
                    FROM dbo.Medicines 
                    WHERE IsDeleted = 0
                    ORDER BY Name";

                using IDbConnection db = new SqlConnection(_connectionString);
                var medicines = await db.QueryAsync<MedicineDto>(sql);

                return ApiResponse<IEnumerable<MedicineDto>>.SuccessResponse(
                    medicines?.ToList() ?? new List<MedicineDto>(),
                    medicines?.Any() == true ? "Medicines retrieved successfully." : "No medicines found.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all medicines.");
                return ApiResponse<IEnumerable<MedicineDto>>.ErrorResponse("Failed to retrieve medicines.", new List<string> { ex.Message });
            }
        }

        // Get Low Stock Medicines (useful for dashboard)
        public async Task<ApiResponse<IEnumerable<MedicineDto>>> GetLowStockMedicines(int threshold = 20)
        {
            try
            {
                const string sql = @"
                    SELECT 
                        Id, Name, GenericName, Description, UnitPrice, 
                        StockQuantity, ExpiryDate
                    FROM dbo.Medicines 
                    WHERE IsDeleted = 0 
                      AND StockQuantity <= @Threshold
                    ORDER BY StockQuantity ASC";

                using IDbConnection db = new SqlConnection(_connectionString);
                var medicines = await db.QueryAsync<MedicineDto>(sql, new { Threshold = threshold });

                return ApiResponse<IEnumerable<MedicineDto>>.SuccessResponse(
                    medicines?.ToList() ?? new List<MedicineDto>(),
                    "Low stock medicines retrieved.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching low stock medicines.");
                return ApiResponse<IEnumerable<MedicineDto>>.ErrorResponse("Failed to retrieve low stock medicines.", new List<string> { ex.Message });
            }
        }

        // Get Medicine by ID
        public async Task<ApiResponse<MedicineDto>> GetMedicineById(int id)
        {
            try
            {
                const string sql = @"
                    SELECT 
                        Id, Name, GenericName, Description, UnitPrice, 
                        StockQuantity, ExpiryDate
                    FROM dbo.Medicines 
                    WHERE Id = @Id AND IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
                var medicine = await db.QueryFirstOrDefaultAsync<MedicineDto>(sql, new { Id = id });

                return medicine != null
                    ? ApiResponse<MedicineDto>.SuccessResponse(medicine, "Medicine retrieved successfully.")
                    : ApiResponse<MedicineDto>.ErrorResponse("Medicine not found.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching medicine {MedicineId}", id);
                return ApiResponse<MedicineDto>.ErrorResponse("Failed to retrieve medicine.", new List<string> { ex.Message });
            }
        }

        // Create New Medicine
        public async Task<ApiResponse<int>> CreateMedicine(CreateMedicineRequest request)
        {
            try
            {
                const string sql = @"
                    INSERT INTO dbo.Medicines 
                        (Name, GenericName, Description, UnitPrice, StockQuantity, ExpiryDate, IsDeleted)
                    VALUES 
                        (@Name, @GenericName, @Description, @UnitPrice, @InitialStock, @ExpiryDate, 0);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                using IDbConnection db = new SqlConnection(_connectionString);
                int medicineId = await db.ExecuteScalarAsync<int>(sql, new
                {
                    request.Name,
                    request.GenericName,
                    request.Description,
                    request.UnitPrice,
                    InitialStock = request.InitialStock,
                    request.ExpiryDate
                });

                return ApiResponse<int>.SuccessResponse(medicineId, "Medicine created successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating medicine: {Name}", request.Name);
                return ApiResponse<int>.ErrorResponse("Failed to create medicine.", new List<string> { ex.Message });
            }
        }

        // Update Medicine Details
        public async Task<ApiResponse<bool>> UpdateMedicine(int id, UpdateMedicineRequest request)
        {
            try
            {
                const string sql = @"
                    UPDATE dbo.Medicines 
                    SET Name = COALESCE(@Name, Name),
                        GenericName = COALESCE(@GenericName, GenericName),
                        Description = COALESCE(@Description, Description),
                        UnitPrice = COALESCE(@UnitPrice, UnitPrice),
                        ExpiryDate = COALESCE(@ExpiryDate, ExpiryDate)
                    WHERE Id = @Id AND IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
                int rows = await db.ExecuteAsync(sql, new
                {
                    Id = id,
                    request.Name,
                    request.GenericName,
                    request.Description,
                    request.UnitPrice,
                    request.ExpiryDate
                });

                return rows > 0
                    ? ApiResponse<bool>.SuccessResponse(true, "Medicine updated successfully.")
                    : ApiResponse<bool>.ErrorResponse("Medicine not found or already deleted.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating medicine {MedicineId}", id);
                return ApiResponse<bool>.ErrorResponse("Failed to update medicine.", new List<string> { ex.Message });
            }
        }

        // Update Stock (Add or Reduce)
        public async Task<ApiResponse<bool>> UpdateStock(StockUpdateRequest request)
        {
            try
            {
                const string sql = @"
                    UPDATE dbo.Medicines 
                    SET StockQuantity = StockQuantity + @Quantity
                    WHERE Id = @MedicineId AND IsDeleted = 0";

                using IDbConnection db = new SqlConnection(_connectionString);
                int rows = await db.ExecuteAsync(sql, new
                {
                    request.MedicineId,
                    request.Quantity
                });

                if (rows > 0)
                {
                    string action = request.Quantity > 0 ? "added to" : "reduced from";
                    return ApiResponse<bool>.SuccessResponse(true,
                        $"Stock {action} successfully. New stock updated.");
                }

                return ApiResponse<bool>.ErrorResponse("Medicine not found.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating stock for medicine {MedicineId}", request.MedicineId);
                return ApiResponse<bool>.ErrorResponse("Failed to update stock.", new List<string> { ex.Message });
            }
        }

        // Optional: Soft Delete
        public async Task<ApiResponse<bool>> DeleteMedicine(int id)
        {
            try
            {
                const string sql = "UPDATE dbo.Medicines SET IsDeleted = 1 WHERE Id = @Id";
                using IDbConnection db = new SqlConnection(_connectionString);
                int rows = await db.ExecuteAsync(sql, new { Id = id });

                return rows > 0
                    ? ApiResponse<bool>.SuccessResponse(true, "Medicine deleted successfully.")
                    : ApiResponse<bool>.ErrorResponse("Medicine not found.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting medicine {MedicineId}", id);
                return ApiResponse<bool>.ErrorResponse("Failed to delete medicine.", new List<string> { ex.Message });
            }
        }
    }
}