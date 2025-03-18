﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.UserIdentityServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class UserController : Controller
{
    private readonly IUserIdentityService _userIdentityService;
    public UserController(IUserIdentityService userIdentityService)
    {
        _userIdentityService = userIdentityService;
    }
    public async Task<IActionResult> UserList()
    {
        var values = await _userIdentityService.GetAllUserListAsync();
        return View(values);
    }
}
