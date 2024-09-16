using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.OrderDtos.OrderAddressDtos;
using MultiShopProject.WebUI.Services.Abstracts;
using MultiShopProject.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShopProject.WebUI.Controllers;

public class OrderController : Controller
{
    private readonly IOrderAddressService _orderAddressService;
    private readonly IUserService _userService;

    public OrderController(IOrderAddressService orderAddressService, IUserService userService)
    {
        _orderAddressService = orderAddressService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        OrderDirectoryList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
    {
        var values = await _userService.GetUserInfo();
        createOrderAddressDto.UserId = values.Id;
        createOrderAddressDto.Description = "aa";

        await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

        return RedirectToAction("Index", "Payment");
    }

    public void OrderDirectoryList()
    {
        ViewBag.directoryProject = "MultiShop Project";
        ViewBag.directoryMain = "Siparişler";
        ViewBag.directoryProduct = "Sipariş İşlemleri";
    }
}
