using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
