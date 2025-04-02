using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
