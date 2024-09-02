﻿using MultiShopProject.Dto.CatalogDtos.OfferDiscountDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.OfferDiscountServices;

public interface IOfferDiscountService
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
    Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
    Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
    Task DeleteOfferDiscountAsync(string id);
    Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
}