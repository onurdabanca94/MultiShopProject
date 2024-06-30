using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents._ContactViewComponents;

public class _ContactFormComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
