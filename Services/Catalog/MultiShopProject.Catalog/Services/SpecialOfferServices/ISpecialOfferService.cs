﻿using MultiShopProject.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShopProject.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
}
