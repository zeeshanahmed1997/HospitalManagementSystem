using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper; // Ensure Dapper is imported

namespace HospitalManagementSystem.DataAccessLayer
{
    public class UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
    {
        private readonly string _connectionString = configuration.GetConnectionString("HMS")
            ?? throw new InvalidOperationException("Connection string 'HMS' not found.");

        public async Task<ApiResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            // Map table columns to DTO properties using AS aliases
            const string sql = @"
                SELECT u.Id, u.FirstName, u.LastName, u.Gender, u.Age, u.Address, 
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

            const string sql = @"
                SELECT u.Id, u.FirstName, u.LastName, u.Gender, u.Age, u.Address, 
                       u.Email, u.PhoneNumber, r.Name AS Role
                FROM AspNetUsers u
                LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
                LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
                WHERE u.Id = @Id";

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
        public async Task<ApiResponse<bool>> UpdateUser(int id, UserDto userDto)
        {             if (userDto is null || id <=0)
                return ApiResponse<bool>.ErrorResponse("User data is invalid.");
            const string sql = @"
                UPDATE AspNetUsers
                SET FirstName = @FirstName,
                    LastName = @LastName, 
                    Email = @Email,
                    Gender = @Gender,
                    Age = @Age,
                    Address = @Address,
                    PhoneNumber = @PhoneNumber
              WHERE Id = @Id";
            //if (userDto.Id == null)
            //    return ApiResponse<bool>.ErrorResponse("User ID is required for update.");
            try
                {
                using IDbConnection db = new SqlConnection(_connectionString);
                int rowsAffected = await db.ExecuteAsync(sql, new
                {
                    userDto.FirstName,
                    userDto.LastName,
                    userDto.Email,
                    userDto.Address,
                    userDto.Gender,
                    userDto.Age,
                    userDto.PhoneNumber,
                    Id = id
                }, null, null, CommandType.Text);
                if (rowsAffected == 0)
                    {
                    return ApiResponse<bool>.ErrorResponse("User not found or no changes made.");
                }
                return ApiResponse<bool>.SuccessResponse(true, "User updated successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating user {Id}", userDto.Id);
                return ApiResponse<bool>.ErrorResponse("Database error.", [ex.Message]);
            }
        }
        public async Task<ApiResponse<UserDto>> CreateUser(UserDto user)
        {
            if (user is null) return ApiResponse<UserDto>.ErrorResponse("User data is null.");

            try
            {
                var passwordHasher = new PasswordHasher<UserDto>();
                string hashedPassword = passwordHasher.HashPassword(user, user.Password ?? "Password@123");

                using IDbConnection db = new SqlConnection(_connectionString);
                db.Open();
                using var transaction = db.BeginTransaction();

                try
                {
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
                        SELECT SCOPE_IDENTITY();";

                    var newUserId = await db.QuerySingleAsync<int>(insertUserSql, new
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        Age = user.Age,
                        Address = user.Address,
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

                    const string insertRoleSql = @"
                        INSERT INTO AspNetUserRoles (UserId, RoleId)
                        SELECT @UserId, Id FROM AspNetRoles WHERE Name = @RoleName;";

                    await db.ExecuteAsync(insertRoleSql, new
                    {
                        UserId = newUserId,
                        RoleName = user.Role ?? "User"
                    }, transaction);

                    transaction.Commit();

                    // Update the DTO with the new ID before returning
                    user.Id = newUserId;
                    return ApiResponse<UserDto>.SuccessResponse(user, "User created successfully.");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
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