﻿using MultiShopProject.Dto.CatalogDtos.SpecialOfferDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly HttpClient _httpClient;

    public SpecialOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _httpClient.DeleteAsync("specialoffers?id=" + id);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllCategoriesAsync()
    {
        //Önceki kullandığımız yöntem;

        //var responseMessage = await _httpClient.GetAsync("categories");
        //var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        //return values;

        var responseMessage = await _httpClient.GetAsync("specialoffers");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
        return values;
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        var responseMessage = await _httpClient.GetAsync("specialoffers");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
        return values;
    }

    public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
        return values;
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
    }
}
