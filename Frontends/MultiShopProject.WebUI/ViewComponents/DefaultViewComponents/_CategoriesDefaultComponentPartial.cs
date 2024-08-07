﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _CategoriesDefaultComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}
