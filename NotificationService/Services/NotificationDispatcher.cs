using NotificationService.Models;
using NotificationService.Services.Interfaces;

namespace NotificationService.Services
{
    public class NotificationDispatcher
    {
        private readonly IServiceProvider _provider;

        public NotificationDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync(NotificationRequest request)
        {
            INotificationSender sender = request.Type switch
            {
                NotificationType.Email => _provider.GetRequiredService<EmailSender>(),
                NotificationType.Sms => _provider.GetRequiredService<SmsSender>(),
                NotificationType.Push => _provider.GetRequiredService<PushSender>(),
                _ => throw new NotSupportedException()
            };

            await sender.SendAsync(request.To, request.Message, request.Subject);
        }
    }
}
