﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _HeadUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
