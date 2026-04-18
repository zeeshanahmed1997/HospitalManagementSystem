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
        public async Task<ApiResponse<IEnumerable<UserDto>>> GetDoctors()
        {
            try
            {
                const string sql = @"
            SELECT 
                u.Id, 
                u.FirstName, 
                u.LastName, 
                u.Gender, 
                u.Age, 
                u.Address,
                u.Email, 
                u.PhoneNumber, 
                r.Name AS Role,
                d.Specialization AS Speciality,      
                d.ConsultationFee,
                d.Qualification
            FROM AspNetUsers u
            INNER JOIN AspNetUserRoles ur ON u.Id = ur.UserId
            INNER JOIN AspNetRoles r ON ur.RoleId = r.Id
            LEFT JOIN Doctors d ON d.UserId = u.Id          -- ← Correct join on UserId
            WHERE u.IsDeleted = 0 
              AND d.IsDeleted = 0
              AND r.Name = 'Doctor'
            ORDER BY u.FirstName, u.LastName;";

                using IDbConnection db = new SqlConnection(_connectionString);

                var doctors = await db.QueryAsync<UserDto>(sql);

                if (!doctors.Any())
                {
                    return ApiResponse<IEnumerable<UserDto>>.ErrorResponse("No doctors found.");
                }

                return ApiResponse<IEnumerable<UserDto>>.SuccessResponse(doctors, $"Successfully retrieved {doctors.Count()} doctors.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<UserDto>>.ErrorResponse("Failed to retrieve doctors.", new[] { ex.Message });
            }
        }
        public async Task<ApiResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            // Map table columns to DTO properties using AS aliases
            const string sql = @"
                SELECT u.Id, u.FirstName, u.LastName, u.Gender, u.Age, u.Address, 
                       u.Email, u.PhoneNumber, r.Name AS Role
                FROM AspNetUsers u
                LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
                LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id where u.IsDeleted=0";

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
                WHERE u.Id = @Id and u.IsDeleted=0";

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
        public async Task<ApiResponse<bool>> DeleteUser(int id)
        {
            if (id <= 0)
                return ApiResponse<bool>.ErrorResponse("Invalid user ID.");
            const string sql = "update AspNetUsers set IsDeleted=1 WHERE Id = @Id";
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
                if (rowsAffected == 0)
                    return ApiResponse<bool>.ErrorResponse("User not found.");
                return ApiResponse<bool>.SuccessResponse(true, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting user {Id}", id);
                return ApiResponse<bool>.ErrorResponse("Database error.", [ex.Message]);
            }
        }
        public async Task<ApiResponse<List<UserDto>>> GetPatientsByDoctor(int userId)
        {
            // 1. Get the actual DoctorId from the Doctors table using the UserId
            const string doctorLookupSql = "SELECT Id FROM Doctors WHERE UserId = @UserId";

            const string patientsSql = @"
        SELECT DISTINCT
            u.Id, 
            u.FirstName, 
            u.LastName,
            u.Email,
            u.PhoneNumber
        FROM AspNetUsers u
        INNER JOIN Patients p ON p.UserId = u.Id
        INNER JOIN Appointments a ON a.PatientId = p.Id
        WHERE a.DoctorId = @DoctorId 
          AND u.IsDeleted = 0 
          AND p.IsDeleted = 0";

            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);

                // Step 1: Find the Doctor record
                var actualDoctorId = await db.ExecuteScalarAsync<int?>(doctorLookupSql, new { UserId = userId });

                if (actualDoctorId == null)
                {
                    return ApiResponse<List<UserDto>>.ErrorResponse("Doctor profile not found for this user.");
                }

                // Step 2: Use that DoctorId to find patients
                var patients = await db.QueryAsync<UserDto>(patientsSql, new { DoctorId = actualDoctorId });

                if (patients == null || !patients.Any())
                {
                    return ApiResponse<List<UserDto>>.ErrorResponse("No patients found for this doctor.");
                }

                return ApiResponse<List<UserDto>>.SuccessResponse(
                    patients.ToList(),
                    $"Successfully retrieved {patients.Count()} patients."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<List<UserDto>>.ErrorResponse("Database error.", new[] { ex.Message });
            }
        }
        public async Task<ApiResponse<List<UserDto>>> GetPatients()
            {
            const string sql = @"
        SELECT
    u.Id,
    u.FirstName,
    u.LastName,
    u.Email,
    u.PhoneNumber,
    r.Name AS Role,
    p.BloodGroup,
    p.EmergencyContact
FROM AspNetUsers u
INNER JOIN AspNetUserRoles ur ON u.Id = ur.UserId
INNER JOIN AspNetRoles r ON ur.RoleId = r.Id
INNER JOIN Patients p ON p.UserId = u.Id
WHERE r.Name = 'Patient' AND u.IsDeleted = 0 AND p.IsDeleted = 0
ORDER BY u.FirstName, u.LastName;";
            try
            {
                using IDbConnection db = new SqlConnection(_connectionString);
                var patients = await db.QueryAsync<UserDto>(sql);
                if (patients == null || !patients.Any())
                {
                    return ApiResponse<List<UserDto>>.ErrorResponse("No patients found.");
                }
                return ApiResponse<List<UserDto>>.SuccessResponse(patients.ToList(), $"Successfully retrieved {patients.Count()} patients.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching patients.");
                return ApiResponse<List<UserDto>>.ErrorResponse("Failed to retrieve patients.", new[] { ex.Message });
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
                SELECT CAST(SCOPE_IDENTITY() as int);";

                    var newUserId = await db.QuerySingleAsync<int>(insertUserSql, new
                    {
                        user.FirstName,
                        user.LastName,
                        user.Gender,
                        user.Age,
                        user.Address,
                        UserName = user.Email,
                        NormalizedUserName = user.Email?.ToUpper(),
                        Email = user.Email,
                        NormalizedEmail = user.Email?.ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = hashedPassword,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        user.PhoneNumber,
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
                        RoleName = user.Role
                    }, transaction);
                    if (user.Role.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                    {
                        const string insertDoctorSql = @"
        INSERT INTO Doctors (UserId, Specialization, ConsultationFee, DepartmentId, IsDeleted)
        VALUES (@UserId, @Specialization, @Fee, @DeptId, 0);";

                        await db.ExecuteAsync(insertDoctorSql, new
                        {
                            UserId = newUserId,
                            Specialization = user.Speciality,
                            Fee = user.ConsultationFee ?? 0,
                            DeptId = user.DepartmentId // Map from DTO
                        }, transaction);
                    }
                    else if (user.Role.Equals("Patient", StringComparison.OrdinalIgnoreCase))
                    {
                        const string insertPatientSql = @"
                    INSERT INTO Patients (UserId, BloodGroup, EmergencyContact, IsDeleted)
                    VALUES (@UserId, @BloodGroup, @EmergencyContact, 0);";

                        await db.ExecuteAsync(insertPatientSql, new
                        {
                            UserId = newUserId,
                            user.BloodGroup,
                            user.EmergencyContact
                        }, transaction);
                    }

                    transaction.Commit();
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