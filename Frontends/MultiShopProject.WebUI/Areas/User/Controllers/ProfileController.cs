﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
