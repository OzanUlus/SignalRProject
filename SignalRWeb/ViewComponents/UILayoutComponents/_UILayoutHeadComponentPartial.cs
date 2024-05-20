using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
