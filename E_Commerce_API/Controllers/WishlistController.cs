﻿using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    public class WishlistController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
