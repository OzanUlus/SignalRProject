using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
