using Farid.Domains.LMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farid.LMS
{
    public class NotificationAppService : FaridAppServiceBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly NotificationHub notificationHub;
        private readonly NotificationRepository _notificationRepository;

        public NotificationAppService(NotificationHub notificationHub,NotificationRepository notificationRepository, IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
            this.notificationHub = notificationHub;
            _notificationRepository = notificationRepository;

        }


        [HttpPost("send")]
        public async Task SendNotification(string user, string message, string recipient, string objectId, string notificationType)
        {
            var notification = new Notification
            {
                User = user,
                Message = message,
                Recipient = recipient,
                ObjectId = objectId,
                NotificationType = notificationType,
                Timestamp = DateTime.UtcNow,
                IsRead = false
            };
            var users = await notificationHub.GetOnlineUsers();
            var SelectedUser = users.Where(a=>a.Id==recipient).FirstOrDefault();
            await _notificationRepository.AddNotification(notification);
            
            if (!string.IsNullOrEmpty(recipient))
            {
                await _hubContext.Clients.Client(SelectedUser.ConnectionId).SendAsync("ReceiveNotification", notification);
            }
            else
            {
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
            }
           


        }

        [HttpGet("GetAllNotifications")]
        public async Task<List<Notification>> GetNotifications(string recipient)
        {
            var notifications = await _notificationRepository.GetNotifications(recipient);
            return notifications;

        }

        [HttpGet("mark-as-read/{id}")]
        public async Task MarkAsRead(int id)
        {
            await _notificationRepository.MarkAsRead(id);

        }
    }
}
