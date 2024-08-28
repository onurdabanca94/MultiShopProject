using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShopProject.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailFeatureComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductService _productService;

    public _ProductDetailFeatureComponentPartial(/*IHttpClientFactory httpClientFactory*/ IProductService productService)
    {
        //_httpClientFactory = httpClientFactory;
        _productService = productService;
    }
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _productService.GetByIdProductAsync(id);
        return View(values);

        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Products/" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
    }
}
