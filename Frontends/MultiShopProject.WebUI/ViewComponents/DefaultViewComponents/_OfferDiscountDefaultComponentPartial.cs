using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _OfferDiscountDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
