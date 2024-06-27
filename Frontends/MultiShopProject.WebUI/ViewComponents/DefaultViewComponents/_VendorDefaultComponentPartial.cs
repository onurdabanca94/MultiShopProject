using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _VendorDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
