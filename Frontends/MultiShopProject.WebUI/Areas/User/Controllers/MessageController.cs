﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

public class MessageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
