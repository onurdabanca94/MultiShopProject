﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInformationComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
