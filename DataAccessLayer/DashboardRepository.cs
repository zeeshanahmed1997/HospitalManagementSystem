using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class DashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets key statistics for Admin Dashboard using pure Dapper.
        /// Updated to match Bills table schema: [TotalAmount] and [IsDeleted].
        /// </summary>
        public async Task<DashboardStatsResponse> GetAdminDashboardStatsAsync()
        {
            // Note: We use TotalAmount instead of Amount, 
            // and filter by IsDeleted = 0 to exclude deleted bills.
            const string sql = @"
                SELECT 
                    (SELECT COUNT(*) FROM Patients) AS TotalPatients,
                    
                    (SELECT COUNT(*) 
                     FROM Doctors 
                     WHERE IsDeleted = 0) AS ActiveDoctors,
                    
                    ISNULL((SELECT SUM(TotalAmount) 
                            FROM Bills 
                            WHERE IsPaid = 1 AND IsDeleted = 0), 0) AS Revenue,
                    
                    ISNULL((SELECT SUM(TotalAmount) 
                            FROM Bills 
                            WHERE IsPaid = 0 AND IsDeleted = 0), 0) AS PendingBills;";

            try
            {
                using IDbConnection connection = new SqlConnection(_connectionString);

                var result = await connection.QueryFirstOrDefaultAsync<DashboardStatsResponse>(sql);

                if (result == null)
                {
                    return new DashboardStatsResponse
                    {
                        Success = false,
                        Message = "No data found for dashboard statistics."
                    };
                }

                result.Success = true;
                return result;
            }
            catch (Exception ex)
            {
                return new DashboardStatsResponse
                {
                    Success = false,
                    Message = $"Error fetching dashboard stats: {ex.Message}"
                };
            }
        }
    }
}