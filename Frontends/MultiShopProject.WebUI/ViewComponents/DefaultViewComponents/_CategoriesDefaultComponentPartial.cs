using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShopProject.WebUI.ViewComponents.DefaultViewComponents;

public class _CategoriesDefaultComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    private readonly ICategoryService _categoryService;

    public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Categories");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        //    return View(values);
        //}

        //return View();
        #endregion
        var values = await _categoryService.GetAllCategoriesAsync();
        return View(values);
    }
}
