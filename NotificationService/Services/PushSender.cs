using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using NotificationService.Services.Interfaces;

namespace NotificationService.Services
{
    public class PushSender : INotificationSender
    {
        public PushSender()
        {
            if(FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.GetApplicationDefault()
                });
            }
        }

        public async Task SendAsync(string to, string message, string? subject = null)
        {
            var msg = new Message
            {
                Token = to,
                Notification = new Notification
                {
                    Title = subject ?? "Notification",
                    Body = message
                }
            };

            await FirebaseMessaging.DefaultInstance.SendAsync(msg);
        }
    }
}
