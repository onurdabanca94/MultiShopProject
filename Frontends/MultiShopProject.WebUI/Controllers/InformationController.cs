using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers;

public class InformationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
