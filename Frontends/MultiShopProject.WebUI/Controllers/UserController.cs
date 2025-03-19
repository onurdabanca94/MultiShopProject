using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.Abstracts;

namespace MultiShopProject.WebUI.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _userService.GetUserInfo();
        return View(values);
    }
}
