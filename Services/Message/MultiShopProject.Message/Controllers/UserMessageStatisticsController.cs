﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Message.Services;

namespace MultiShopProject.Message.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserMessageStatisticsController : ControllerBase
{
    private readonly IUserMessageService _userMessageService;

    public UserMessageStatisticsController(IUserMessageService userMessageService)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int messageCount = await _userMessageService.GetTotalMessageCount();
        return Ok(messageCount);
    }
}
