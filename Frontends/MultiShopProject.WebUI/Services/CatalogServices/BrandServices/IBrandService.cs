﻿using MultiShopProject.Dto.CatalogDtos.BrandDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task DeleteBrandAsync(string id);
    Task<UpdateBrandDto> GetByIdBrandAsync(string id);
}
