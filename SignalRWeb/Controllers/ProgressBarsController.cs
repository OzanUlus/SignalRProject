using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class ProgressBarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
