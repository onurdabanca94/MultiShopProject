﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
