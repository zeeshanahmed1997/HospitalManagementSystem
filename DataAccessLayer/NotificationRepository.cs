using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class NotificationRepository
    {
        private readonly string _connectionString;

        public NotificationRepository(string connectionString) => _connectionString = connectionString;

        public async Task CreateNotificationAsync(int userId, string title, string message, string type, long? relatedId = null)
        {
            const string sql = @"
            INSERT INTO Notifications (UserId, Title, Message, Type, RelatedId)
            VALUES (@UserId, @Title, @Message, @Type, @RelatedId);";

            using IDbConnection conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(sql, new { UserId = userId, Title = title, Message = message, Type = type, RelatedId = relatedId });
        }

        // GetUnreadNotificationsAsync, MarkAsReadAsync etc.
    }
}
