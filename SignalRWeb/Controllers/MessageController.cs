using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
