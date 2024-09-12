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
    public async Task<IActionResult> ConfirmDiscountCoupon(string code)
    {
        var values = await _discountService.GetDiscountCouponCountRate(code);
        var basketValues = await _basketService.GetBasket();
        var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100 * 10);
        var totalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
        //ViewBag.totalPriceWithDiscount = totalPriceWithDiscount;

        return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values, totalPriceWithDiscount = totalPriceWithDiscount });

        #region Old Method
        // ikinci yorum satırına aldığımız bölüm
        //var values = _discountService.GetDiscountCode(code);
        //var basketValues = await _basketService.GetBasket();
        //var totalPriceWithTax = basketValues.TotalPrice + (basketValues.TotalPrice / 100 * 10);

        //var totalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * 20);
        //ViewBag.totalPriceWithDiscount = totalPriceWithDiscount;


        // ilk yorum satırına aldığımız bölüm
        //var values = await _basketService.GetBasket();
        //ViewBag.total = values.TotalPrice;
        //var totalPriceWithTax = values.TotalPrice + (values.TotalPrice / 100 * 10);
        //var tax = values.TotalPrice / 100 * 10;
        //ViewBag.totalPriceWithTax = totalPriceWithTax;
        //ViewBag.tax = tax;
        //return View();
        #endregion
    }
}
