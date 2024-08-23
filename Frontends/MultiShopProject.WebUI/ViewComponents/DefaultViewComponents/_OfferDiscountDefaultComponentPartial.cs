using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _OfferDiscountDefaultComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _OfferDiscountDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    private readonly IOfferDiscountService _offerDiscountService;

    public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
    {
        _offerDiscountService = offerDiscountService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/OfferDiscounts");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
        //    return View(values);
        //}

        //return View();
        #endregion
        var values = await _offerDiscountService.GetAllOfferDiscountAsync();
        return View(values);
    }
}
