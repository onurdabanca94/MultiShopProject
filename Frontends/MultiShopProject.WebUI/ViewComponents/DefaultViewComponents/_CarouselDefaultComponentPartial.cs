using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _CarouselDefaultComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
