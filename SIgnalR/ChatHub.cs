using HospitalManagementSystem.DataAccessLayer;
using HospitalManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace HospitalManagementSystem.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ChatRepository _chatRepository;

        public ChatHub(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task SendMessage(SendChatMessageRequest request)
        {
            var senderIdStr = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(senderIdStr) || !int.TryParse(senderIdStr, out int senderId))
            {
                await Clients.Caller.SendAsync("ReceiveError", "Invalid user identity.");
                return;
            }

            if (request?.ReceiverId <= 0 || string.IsNullOrWhiteSpace(request.MessageText))
            {
                await Clients.Caller.SendAsync("ReceiveError", "Invalid message data.");
                return;
            }

            try
            {
                var savedMessage = await _chatRepository.SaveMessageAsync(
                    senderId,
                    request.ReceiverId,
                    request.MessageText.Trim());

                var messageDto = new ChatMessageDto
                {
                    Id = savedMessage.Id,
                    SenderId = senderId,
                    ReceiverId = request.ReceiverId,
                    MessageText = request.MessageText.Trim(),
                    SentAt = DateTime.UtcNow,
                    IsRead = false
                };

                // Send to receiver
                await Clients.User(request.ReceiverId.ToString()).SendAsync("ReceiveMessage", messageDto);

                // Echo to sender
                await Clients.Caller.SendAsync("ReceiveMessage", messageDto);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ReceiveError", $"Server error: {ex.Message}");
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"[SignalR] User {userId} connected. ConnectionId: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine($"[SignalR] User {userId} disconnected.");
            await base.OnDisconnectedAsync(exception);
        }
    }
}