using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShopProject.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class StatisticController : Controller
{
    private readonly ICatalogStatisticService _catalogStatisticService;
    private readonly IUserStatisticService _userStatisticService;
    public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService)
    {
        _catalogStatisticService = catalogStatisticService;
        _userStatisticService = userStatisticService;
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

        var getUserCount = await _userStatisticService.GetUserCount();
        //var getProductAvgPrice = await _catalogStatisticService.GetProductAvgPrice();

        ViewBag.getBrandCount = getBrandCount;
        ViewBag.getProductCount = getProductCount;
        ViewBag.getCategoryCount = getCategoryCount;
        ViewBag.getMaxPriceProductName = getMaxPriceProductName;
        ViewBag.getMinPriceProductName = getMinPriceProductName;

        ViewBag.getUserCount = getUserCount;
        //ViewBag.getProductAvgPrice = getProductAvgPrice;
    }
}
