using Microsoft.AspNetCore.Mvc;
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

	public IActionResult Index()
	{
		ViewBag.directoryProject = "Ana Sayfa";
		ViewBag.directoryMain = "Ürünler";
		ViewBag.directoryProduct = "Sepetim";
		return View();
		//var values = await _basketService.GetBasket();
		//return View(values);
	}

	public async Task<IActionResult> AddBasketItem(string productId)
	{
		var values = await _productService.GetByIdProductAsync(productId);
		var items = new BasketItemDto
		{
			ProductId = values.ProductId,
			ProductName = values.ProductName,
			Price = values.ProductPrice,
			Quantity = 1 //Başlangıçta 1 öge alsın. Dışarıdan değer göndericez bu sadece örnek.
		};
		await _basketService.AddBasketItem(items);
		return RedirectToAction("Index");
	}

	public async Task<IActionResult> RemoveBasketItem(string productId)
	{
		await _basketService.RemoveBasketItem(productId);
		return RedirectToAction("Index");
	}
}
