using Microsoft.AspNetCore.Mvc;
using NotificationService.Background;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Send([FromBody] NotificationRequest request)
        {
            NotificationBackgroundWorker.Enqueue(request);
            return Accepted(new { status = "Accepted" });
        }
    }
}
