using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
