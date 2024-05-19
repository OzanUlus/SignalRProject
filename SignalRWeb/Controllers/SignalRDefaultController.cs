using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
