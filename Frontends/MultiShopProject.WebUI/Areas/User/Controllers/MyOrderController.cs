using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

[Area("User")]
public class MyOrderController : Controller
{
    public IActionResult MyOrderList()
    {
        return View();
    }
}
