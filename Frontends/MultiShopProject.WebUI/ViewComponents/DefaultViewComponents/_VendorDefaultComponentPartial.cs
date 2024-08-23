using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _VendorDefaultComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _VendorDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    private readonly IBrandService _brandService;

    public _VendorDefaultComponentPartial(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Brands");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
        var values = await _brandService.GetAllBrandsAsync();
        return View(values);
    }
}
