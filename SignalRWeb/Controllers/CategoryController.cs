﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
