﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
