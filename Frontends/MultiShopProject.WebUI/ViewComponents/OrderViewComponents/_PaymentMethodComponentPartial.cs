using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.OrderViewComponents;

public class _PaymentMethodComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
