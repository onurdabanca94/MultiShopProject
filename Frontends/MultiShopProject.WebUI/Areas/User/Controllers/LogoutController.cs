using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

public class LogoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
