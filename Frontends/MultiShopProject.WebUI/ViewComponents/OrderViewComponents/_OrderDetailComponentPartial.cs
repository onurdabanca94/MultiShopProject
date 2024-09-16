using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.OrderViewComponents;

public class _OrderDetailComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
