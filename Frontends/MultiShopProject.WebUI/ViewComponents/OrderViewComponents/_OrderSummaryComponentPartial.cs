using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.BasketServices;

namespace MultiShopProject.WebUI.ViewComponents.OrderViewComponents;

public class _OrderSummaryComponentPartial : ViewComponent
{
    private readonly IBasketService _basketService;

    public _OrderSummaryComponentPartial(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        //var values = await _basketService.GetBasket();
        //return View(values);
        var basketTotal = await _basketService.GetBasket();
        var basketItems = basketTotal.BasketItems;
        return View(basketItems);
    }
}
