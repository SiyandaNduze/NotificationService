using System.Collections.Concurrent;
using NotificationService.Models;
using NotificationService.Services;

namespace NotificationService.Background
{
    public class NotificationBackgroundWorker : BackgroundService
    {
        private static readonly ConcurrentQueue<NotificationRequest> Queue = new();
        private readonly NotificationDispatcher _dispatcher;

        public static void Enqueue(NotificationRequest request)
        {
            Queue.Enqueue(request);
        }

        public NotificationBackgroundWorker(NotificationDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (Queue.TryDequeue(out var notification))
                {
                    try
                    {
                        await _dispatcher.DispatchAsync(notification);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
