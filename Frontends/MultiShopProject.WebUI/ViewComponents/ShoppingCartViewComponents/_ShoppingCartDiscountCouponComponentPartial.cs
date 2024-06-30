using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
