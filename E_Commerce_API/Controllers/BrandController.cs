﻿using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    public class BrandController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
