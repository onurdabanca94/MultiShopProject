﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _FeatureProductsDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
