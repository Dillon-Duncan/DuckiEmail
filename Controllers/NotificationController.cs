using Microsoft.AspNetCore.Mvc;

namespace DuckiEmail.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ISubject eventNotifier;

        public NotificationController(ISubject eventNotifier)
        {
            eventNotifier = eventNotifier;
        }

        public IActionResult Subscribe()
        {
            var observer = new EmailObserver();
            eventNotifier.Attach(observer);
            return Ok("Subscribed");
        }

        public IActionResult Unsubscribe()
        {
            var observer = new EmailObserver();
            eventNotifier.Detach(observer);
            return Ok("Unsubscribed");
        }

        public IActionResult Notify(string message)
        {
            eventNotifier.Notify(message);
            return Ok("Notified");
        }
    }
}
