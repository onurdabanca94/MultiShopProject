﻿using MultiShopProject.Dto.CatalogDtos.ProductDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _httpClient.DeleteAsync("products?id=" + id);
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("products");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
        return values;
    }

    public async Task<UpdateProductDto> GetByIdProductAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("products/" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
        return values;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
    {
        var responseMessage = await _httpClient.GetAsync("products");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
        return values;
    }

    public Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
    }
}
