using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartProductListComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
