﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
