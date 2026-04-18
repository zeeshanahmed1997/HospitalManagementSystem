using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class DepartmentRepository(IConfiguration configuration, ILogger<AppointmentRepository> logger)
    {

        private readonly string _connectionString = configuration.GetConnectionString("HMS")
          ?? throw new InvalidOperationException("Connection string 'HMS' not found.");
        public async Task<ApiResponse<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            const string sql = @"
                SELECT Id, Name
                FROM Departments";
            using IDbConnection db = new SqlConnection(_connectionString);
            try
            {
                var departments = await db.QueryAsync<DepartmentDto>(sql);
                return ApiResponse<IEnumerable<DepartmentDto>>.SuccessResponse(departments);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching departments from database.");
                return ApiResponse<IEnumerable<DepartmentDto>>.ErrorResponse("An error occurred while fetching departments.");
            }
        }
    }
}
