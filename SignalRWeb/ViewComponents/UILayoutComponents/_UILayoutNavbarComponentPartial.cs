using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
          return View();
        }
    }
}
