using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
