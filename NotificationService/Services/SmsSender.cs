using NotificationService.Services.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace NotificationService.Services
{
    public class SmsSender : INotificationSender
    {
        private readonly IConfiguration _config;

        public SmsSender(IConfiguration config)
        {
            _config = config;
            TwilioClient.Init(
                _config["Twilio:AccountSid"],
                _config["Twilio:AuthToken"]
                );
        }

        public async Task SendAsync(string to, string message, string? subject = null)
        {
            await MessageResource.CreateAsync(
                body: message,
                from: _config["Twilio:From"],
                to: to
                );
        }
    }
}
