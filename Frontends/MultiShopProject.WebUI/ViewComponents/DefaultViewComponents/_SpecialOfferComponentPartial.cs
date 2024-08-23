using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _SpecialOfferComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _SpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    private readonly ISpecialOfferService _specialOfferService;

    public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/SpecialOffers");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
        //    return View(values);
        //}

        //return View();
        #endregion
        var values = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(values);
    }
}
