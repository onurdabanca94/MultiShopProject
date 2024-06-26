using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _NavbarUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
