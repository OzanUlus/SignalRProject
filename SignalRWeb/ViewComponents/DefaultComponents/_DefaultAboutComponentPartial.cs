﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
