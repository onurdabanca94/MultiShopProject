using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StatisticController : Controller
{
    private readonly ICatalogStatisticService _catalogStatisticService;
    public StatisticController(ICatalogStatisticService catalogStatisticService)
    {
        _catalogStatisticService = catalogStatisticService;
    }
    public async Task<IActionResult> Index()
    {
        await StatisticsAllSection();

        return View();
    }

    private async Task StatisticsAllSection()
    {
        var getBrandCount = await _catalogStatisticService.GetBrandCount();
        var getProductCount = await _catalogStatisticService.GetProductCount();
        var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
        var getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
        var getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
        //var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();

        ViewBag.getBrandCount = getBrandCount;
        ViewBag.getProductCount = getProductCount;
        ViewBag.getCategoryCount = getCategoryCount;
        ViewBag.getMaxPriceProductName = getMaxPriceProductName;
        ViewBag.getMinPriceProductName = getMinPriceProductName;
        //ViewBag.getProductAvgPrice = getProductAvgPrice;
    }
}
