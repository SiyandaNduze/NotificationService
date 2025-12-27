namespace NotificationService.Services.Interfaces
{
    public interface INotificationSender
    {
        Task SendAsync(string to, string message, string? subject = null);
    }
}
