using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents._ContactViewComponents;

public class _ContactDetailComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
