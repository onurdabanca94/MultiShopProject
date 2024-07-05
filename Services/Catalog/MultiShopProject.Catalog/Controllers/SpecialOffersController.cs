﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.SpecialOfferDtos;
using MultiShopProject.Catalog.Services.SpecialOfferServices;

namespace MultiShopProject.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialOffersController : ControllerBase
{
    private readonly ISpecialOfferService _specialOfferService;

    public SpecialOffersController(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    [HttpGet]
    public async Task<IActionResult> SpecialOfferList()
    {
        var values = await _specialOfferService.GetAllSpecialOfferAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOfferById(string id)
    {
        var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
        return Ok("Special Offer has been created!");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);
        return Ok("Special Offer has been removed!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
        return Ok("Special Offer has been updated!");
    }
}
