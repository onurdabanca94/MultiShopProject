﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.BasketDtos;
using MultiShopProject.WebUI.Services.BasketServices;
using MultiShopProject.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShopProject.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IProductService _productService;
    private readonly IBasketService _basketService;

    public ShoppingCartController(IProductService productService, IBasketService basketService)
    {
        _productService = productService;
        _basketService = basketService;
    }

    public async Task<IActionResult> Index(string code, int discountRate, decimal totalPriceWithDiscount)
    {
        ViewBag.code = code;
        ViewBag.discountRate = discountRate;
        ViewBag.totalPriceWithDiscount = totalPriceWithDiscount;
        ViewBag.directoryProject = "Ana Sayfa";
        ViewBag.directoryMain = "Ürünler";
        ViewBag.directoryProduct = "Sepetim";
        var values = await _basketService.GetBasket();
        ViewBag.total = values.TotalPrice;
        var totalPriceWithTax = values.TotalPrice + (values.TotalPrice / 100 * 10);
        var tax = values.TotalPrice / 100 * 10;
        ViewBag.totalPriceWithTax = totalPriceWithTax;
        ViewBag.tax = tax;
        return View();
        //var values = await _basketService.GetBasket();
        //return View(values);
    }

    public async Task<IActionResult> AddBasketItem(string id)
    {
        var values = await _productService.GetByIdProductAsync(id);
        var items = new BasketItemDto
        {
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            Price = values.ProductPrice,
            Quantity = 1, //Başlangıçta 1 öge alsın. Dışarıdan değer göndericez bu sadece örnek.
            ProductImageUrl = values.ProductImageUrl
        };
        await _basketService.AddBasketItem(items);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveBasketItem(string id)
    {
        await _basketService.RemoveBasketItem(id);
        return RedirectToAction("Index");
    }
}
