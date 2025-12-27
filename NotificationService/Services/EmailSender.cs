using System.Net;
using System.Net.Mail;
using NotificationService.Services.Interfaces;

namespace NotificationService.Services
{
    public class EmailSender : INotificationSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string message, string? subject = null)
        {
            var smtp = new SmtpClient(
                _config["Smtp:Host"],
                int.Parse(_config["Smtp:Port"]!))
            {
                Credentials = new NetworkCredential(
                    _config["Smtp:Username"],
                    _config["Smtp:Password"]),
                EnableSsl = true
            };

            var mail = new MailMessage(
                _config["Smtp:From"]!,
                to,
                subject ?? "Notification",
                message);
            
            await smtp.SendMailAsync(mail);
        }
    }
}
