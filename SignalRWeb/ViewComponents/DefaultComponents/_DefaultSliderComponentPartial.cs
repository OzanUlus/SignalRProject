using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
          return View();
        }
    }
}
