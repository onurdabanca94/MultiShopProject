﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.FeatureDtos;
using MultiShopProject.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[AllowAnonymous]
[Route("Admin/Feature")]
public class FeatureController : Controller
{
    private readonly IFeatureService _featureService;

    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        FeatureViewBagList();

        var values = await _featureService.GetAllFeaturesAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature()
    {
        FeatureViewBagList();
        return View();
    }

    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        await _featureService.CreateFeatureAsync(createFeatureDto);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    [Route("UpdateFeature/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(string id)
    {
        FeatureViewBagList();
        var values = await _featureService.GetByIdFeatureAsync(id);
        return View(values);
    }

    [Route("UpdateFeature/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        await _featureService.UpdateFeatureAsync(updateFeatureDto);
        return RedirectToAction("Index", "Feature", new { area = "Admin" });
    }

    public void FeatureViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Öne Çıkan Alanlar";
        ViewBag.v3 = "Öne Çıkan Alan Listesi";
        ViewBag.v0 = "Ana Sayfa Öne Çıkan İşlemleri";
    }
}
