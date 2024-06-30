using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
