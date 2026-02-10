using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        /// <summary>
        /// Retrieves all registered users from the system.
        /// </summary>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            // We join the three Identity tables to get the Role Name
            const string sql = @"
        SELECT 
            u.Id, 
            (u.FirstName + ' ' + u.LastName) AS Fullname, 
            u.Email, 
            u.PhoneNumber, 
            r.Name AS Role
        FROM AspNetUsers u
        LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
        LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id";

            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                logger.LogInformation("Fetching all users with roles using Dapper.");

                var users = await db.QueryAsync<UserDto>(sql);
                return users ?? Enumerable.Empty<UserDto>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetAllUsersAsync with Dapper.");
                throw;
            }
        }

        /// <summary>
        /// Finds a specific user by their unique identifier.
        /// </summary>
        /// <param name="userId">The GUID string of the user.</param>
        public async Task<UserDto?> GetUserByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                logger.LogWarning("GetUserByIdAsync called with a null or empty userId.");
                return null;
            }

            const string sql = @"SELECT Id, UserName, Email, PhoneNumber 
                                 FROM AspNetUsers 
                                 WHERE Id = @Id";

            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);

                var user = await db.QueryFirstOrDefaultAsync<UserDto>(sql, new { Id = userId });

                if (user == null)
                {
                    logger.LogWarning("User with ID: {UserId} was not found.", userId);
                }

                return user;
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "Database connection error while fetching User ID: {UserId}", userId);
                throw new Exception("Error accessing user records.", ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error fetching User ID: {UserId}", userId);
                throw;
            }
        }
    }
}