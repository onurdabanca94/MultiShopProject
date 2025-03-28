using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.Abstracts;
using MultiShopProject.WebUI.Services.MessageServices;

namespace MultiShopProject.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderComponentPartial : ViewComponent
{
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;
    public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService)
    {
        _messageService = messageService;
        _userService = userService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetUserInfo();
        int messageCount = await _messageService.GetTotalMessageCountByReceiverId(user.Id);
        ViewBag.messageCount = messageCount;
        return View();
    }
}
