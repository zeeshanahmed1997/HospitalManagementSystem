using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensures only logged-in users can fetch chats
    public class ChatController : ControllerBase
    {
        private readonly ChatRepository _chatRepository;

        public ChatController(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetHistory(int userId)
        {
            // Security Check: Ensure the logged-in user is requesting their own history
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == null || int.Parse(currentUserId) != userId)
            {
                return Unauthorized("You cannot view other users' chats.");
            }

            var history = await _chatRepository.GetUserChatHistoryAsync(userId);
            return Ok(history);
        }

        [HttpPost("mark-read/{messageId}")]
        public async Task<IActionResult> MarkRead(long messageId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            await _chatRepository.MarkMessageAsReadAsync(messageId, userId);
            return Ok();
        }
    }
}