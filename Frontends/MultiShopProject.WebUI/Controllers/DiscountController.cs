using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.BasketServices;
using MultiShopProject.WebUI.Services.DiscountServices;

namespace MultiShopProject.WebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IDiscountService _discountService;
    private readonly IBasketService _basketService;

    public DiscountController(IDiscountService discountService, IBasketService basketService)
    {
        _discountService = discountService;
        _basketService = basketService;
    }

    [HttpGet]
    public PartialViewResult ConfirmDiscountCoupon()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult ConfirmDiscountCoupon(string code)
    {
        var values = _discountService.GetDiscountCode(code);
        return View(values);
    }
}
