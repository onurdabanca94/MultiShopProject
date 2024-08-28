using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShopProject.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailDescriptionComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductDetailService _productDetailService;

    public _ProductDetailDescriptionComponentPartial(/*IHttpClientFactory httpClientFactory*/ IProductDetailService productDetailService)
    {
        //_httpClientFactory = httpClientFactory;
        _productDetailService = productDetailService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
        return View(values);

        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/ProductDetails/GetProductDetailByProductId?id=" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
    }
}

//GetByProductIdProductDetailAsync
//GetProductDetailByProductId