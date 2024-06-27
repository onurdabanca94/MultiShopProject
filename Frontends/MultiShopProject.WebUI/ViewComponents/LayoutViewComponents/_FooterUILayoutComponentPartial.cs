using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _FooterUILayoutComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
