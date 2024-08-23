using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _CarouselDefaultComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    private readonly IFeatureSliderService _featureSliderService;

    public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/FeatureSliders");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
        //    return View(values);
        //}

        //return View();
        #endregion
        var values = await _featureSliderService.GetAllFeatureSliderAsync();
        return View(values);
    }
}
