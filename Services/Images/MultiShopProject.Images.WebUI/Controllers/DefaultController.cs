﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Images.WebUI.DataAccessLayer.Entities;
using MultiShopProject.Images.WebUI.Services;

namespace MultiShopProject.Images.WebUI.Controllers;

public class DefaultController : Controller
{
    private readonly ICloudStorageService _cloudStorageService;

    public DefaultController(ICloudStorageService cloudStorageService)
    {
        _cloudStorageService = cloudStorageService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ImageDrive imageDrive)
    {
        if (imageDrive.Photo != null)
        {
            imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
            imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
        }
        return RedirectToAction("Index", "Default");
    }

    private string? GenerateFileNameToSave(string incomingFileName)
    {
        var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
        var extension = Path.GetExtension(incomingFileName);
        return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
    }
}