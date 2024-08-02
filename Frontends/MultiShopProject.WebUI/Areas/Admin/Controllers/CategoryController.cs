using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.CategoryDtos;
using MultiShopProject.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[AllowAnonymous]
[Route("Admin/Category")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ICategoryService _categoryService;

    public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
    {
        _httpClientFactory = httpClientFactory;
        _categoryService = categoryService;
    }



    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("http://localhost:7192/api/Categories");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        //    return View(values);
        //}
        #endregion
        CategoryViewBagList();
        var values = await _categoryService.GetAllCategoriesAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory()
    {
        CategoryViewBagList();
        return View();
    }

    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(createCategoryDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
        //var responseMessage = await client.PostAsync("https://localhost:7192/api/Categories", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Category", new { area = "Admin" });
        //}
        //return View();
        #endregion
        await _categoryService.CreateCategoryAsync(createCategoryDto);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.DeleteAsync("https://localhost:7192/api/Categories?id=" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Category", new { area = "Admin" });
        //}
        //return View();
        #endregion
    }

    [Route("UpdateCategory/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        CategoryViewBagList();
        var values = await _categoryService.GetByIdCategoryAsync(id);
        return View(values);
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Categories/" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
    }

    [Route("UpdateCategory/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //var responseMessage = await client.PutAsync("https://localhost:7192/api/Categories/", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Category", new { area = "Admin" });
        //}
        //return View();
        #endregion
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);
        return RedirectToAction("Index", "Category", new { area = "Admin" });
    }

    public void CategoryViewBagList()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Kategoriler";
        ViewBag.v3 = "Kategori Listesi";
        ViewBag.v0 = "Kategori İşlemleri";
    }
}
