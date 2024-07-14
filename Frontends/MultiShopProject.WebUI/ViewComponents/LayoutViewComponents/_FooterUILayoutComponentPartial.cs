﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _FooterUILayoutComponentPartial : ViewComponent
{

    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
