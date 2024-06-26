using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _TopbarUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
