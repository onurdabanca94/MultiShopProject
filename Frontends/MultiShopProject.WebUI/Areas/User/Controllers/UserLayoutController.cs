using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

[Area("User")]
public class UserLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
