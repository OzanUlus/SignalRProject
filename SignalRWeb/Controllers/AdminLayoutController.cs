using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
