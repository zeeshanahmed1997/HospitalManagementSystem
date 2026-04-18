using Dapper;
using HospitalManagementSystem.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.DataAccessLayer
{
    public class ChatRepository
    {
        private readonly string _connectionString;

        public ChatRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<ChatMessageDto>> GetUserChatHistoryAsync(int userId)
        {
            const string sql = @"
        SELECT 
            m.Id, 
            m.SenderId, 
            m.ReceiverId, 
            m.MessageText, 
            m.SentAt, 
            m.IsRead,
            u.FirstName AS SenderName -- Joining to get the name for the frontend
        FROM ChatMessages m
        INNER JOIN AspNetUsers u ON m.SenderId = u.Id
        WHERE m.SenderId = @UserId OR m.ReceiverId = @UserId
        ORDER BY m.SentAt ASC";

            using IDbConnection conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<ChatMessageDto>(sql, new { UserId = userId });
        }
        public async Task<ChatMessageDto> SaveMessageAsync(int senderId, int receiverId, string messageText)
        {
            const string sql = @"
                INSERT INTO ChatMessages (SenderId, ReceiverId, MessageText)
                OUTPUT INSERTED.Id, INSERTED.SenderId, INSERTED.ReceiverId, 
                       INSERTED.MessageText, INSERTED.SentAt, INSERTED.IsRead
                VALUES (@SenderId, @ReceiverId, @MessageText);";

            using IDbConnection conn = new SqlConnection(_connectionString);
            return await conn.QueryFirstAsync<ChatMessageDto>(sql, new { SenderId = senderId, ReceiverId = receiverId, MessageText = messageText });
        }

        public async Task MarkMessageAsReadAsync(long messageId, int userId)
        {
            const string sql = "UPDATE ChatMessages SET IsRead = 1 WHERE Id = @Id AND ReceiverId = @UserId";
            using IDbConnection conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync(sql, new { Id = messageId, UserId = userId });
        }

        // Add GetConversationAsync, GetUnreadCountAsync etc. as needed
    }
}