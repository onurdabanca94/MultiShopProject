using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShopProject.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductImageService _productImageService;

    public _ProductDetailImageSliderComponentPartial(/*IHttpClientFactory httpClientFactory,*/ IProductImageService productImageService)
    {
        //_httpClientFactory = httpClientFactory;
        _productImageService = productImageService;
    }
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productImageService.GetByProductIdProductImageAsync(id);
        return View(values);

        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/ProductImages/ProductImagesByProductId?id=" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
    }
}
