using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        public async Task<ApiResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            const string sql = @"
                SELECT u.Id, (u.FirstName + ' ' + u.LastName) AS Fullname, 
                       u.Email, u.PhoneNumber, r.Name AS Role
                FROM AspNetUsers u
                LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
                LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id";

            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var users = await db.QueryAsync<UserDto>(sql);
                return ApiResponse<IEnumerable<UserDto>>.SuccessResponse(users, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching users.");
                return ApiResponse<IEnumerable<UserDto>>.ErrorResponse("Failed to retrieve users.", [ex.Message]);
            }
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return ApiResponse<UserDto>.ErrorResponse("User ID is required.");

            const string sql = "SELECT Id, UserName, Email, PhoneNumber FROM AspNetUsers WHERE Id = @Id";

            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var user = await db.QueryFirstOrDefaultAsync<UserDto>(sql, new { Id = userId });

                return user == null
                    ? ApiResponse<UserDto>.ErrorResponse("User not found.")
                    : ApiResponse<UserDto>.SuccessResponse(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching user {Id}", userId);
                return ApiResponse<UserDto>.ErrorResponse("Database error.", [ex.Message]);
            }
        }

        public async Task<ApiResponse<UserDto>> CreateUser(UserDto user)
        {
            if (user is null) return ApiResponse<UserDto>.ErrorResponse("User data is null.");

            try
            {
                var passwordHasher = new PasswordHasher<UserDto>();
                string hashedPassword = passwordHasher.HashPassword(user, user.Password ?? "DefaultPass123!");

                using IDbConnection db = new SqlConnection(_connectionString);
                db.Open();
                using var transaction = db.BeginTransaction();

                try
                {
                    // 1. Remove 'Id' from the column list and the VALUES list
                    // 2. Add 'SELECT SCOPE_IDENTITY()' at the end to get the new ID
                    const string insertUserSql = @"
                INSERT INTO AspNetUsers (
                    FirstName, LastName, Gender, Age, [Address], 
                    UserName, NormalizedUserName, Email, NormalizedEmail, 
                    EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, 
                    PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, 
                    LockoutEnabled, AccessFailedCount
                )
                VALUES (
                    @FirstName, @LastName, @Gender, @Age, @Address, 
                    @UserName, @NormalizedUserName, @Email, @NormalizedEmail, 
                    @EmailConfirmed, @PasswordHash, @SecurityStamp, @ConcurrencyStamp, 
                    @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, 
                    @LockoutEnabled, @AccessFailedCount
                );
                SELECT SCOPE_IDENTITY();"; // This gets the ID created by SQL Server

                    // Use QuerySingleAsync to get the ID back
                    var newUserId = await db.QuerySingleAsync<int>(insertUserSql, new
                    {
                        FirstName = user.Fullname,
                        LastName = user.Fullname,
                        Gender = "Male",
                        Age = 30,
                        Address = "Address",
                        UserName = user.Email,
                        NormalizedUserName = user.Email?.ToUpper(),
                        Email = user.Email,
                        NormalizedEmail = user.Email?.ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hashedPassword,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }, transaction);

                    // 3. Now use that integer 'newUserId' to insert the role
                    const string insertRoleSql = @"
                INSERT INTO AspNetUserRoles (UserId, RoleId)
                SELECT @UserId, Id FROM AspNetRoles WHERE Name = @RoleName;";

                    await db.ExecuteAsync(insertRoleSql, new
                    {
                        UserId = newUserId,
                        RoleName = user.Role ?? "User"
                    }, transaction);

                    transaction.Commit();
                    return ApiResponse<UserDto>.SuccessResponse(user, "User created successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw; // Let the outer catch handle the logging
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating user {Email}", user?.Email);
                return ApiResponse<UserDto>.ErrorResponse("Creation failed.", [ex.Message]);
            }
        }
    }
}