using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.BrandDtos;
using MultiShopProject.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[AllowAnonymous]
[Route("Admin/Brand")]
public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        BrandViewBagList();

        var values = await _brandService.GetAllBrandsAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateBrand")]
    public IActionResult CreateBrand()
    {
        BrandViewBagList();
        return View();
    }

    [HttpPost]
    [Route("CreateBrand")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateBrandAsync(createBrandDto);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }

    [Route("DeleteBrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }

    [Route("UpdateBrand/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        BrandViewBagList();
        var values = await _brandService.GetByIdBrandAsync(id);
        return View(values);
    }

    [Route("UpdateBrand/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);
        return RedirectToAction("Index", "Brand", new { area = "Admin" });
    }

    public void BrandViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Markalar";
        ViewBag.v3 = "Marka Listesi";
        ViewBag.v0 = "Marka İşlemleri";
    }
}
