using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.UILayoutComponents
{
    public class _UILAyoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
