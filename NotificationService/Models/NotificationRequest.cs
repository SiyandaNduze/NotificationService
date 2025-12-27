namespace NotificationService.Models
{
    public enum NotificationType
    {
        Email,
        Sms,
        Push
    }

    public class NotificationRequest
    {
        public NotificationType Type { get; set; }
        public string To { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
