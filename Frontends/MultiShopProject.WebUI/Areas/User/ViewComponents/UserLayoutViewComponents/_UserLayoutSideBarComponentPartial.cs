using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents;

public class _UserLayoutSideBarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
