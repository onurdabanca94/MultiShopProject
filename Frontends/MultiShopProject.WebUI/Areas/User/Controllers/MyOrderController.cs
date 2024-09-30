using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.Abstracts;
using MultiShopProject.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShopProject.WebUI.Areas.User.Controllers;

[Area("User")]
public class MyOrderController : Controller
{
    private readonly IOrderOrderingService _orderOrderingService;
    private readonly IUserService _userService;

    public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
    {
        _orderOrderingService = orderOrderingService;
        _userService = userService;
    }

    public async Task<IActionResult> MyOrderList()
    {
        var user = await _userService.GetUserInfo();
        var values = _orderOrderingService.GetOrderingByUserId(user.Id);
        return View(values);
    }
}
