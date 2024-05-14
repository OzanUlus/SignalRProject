using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
