using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

public class CargoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
