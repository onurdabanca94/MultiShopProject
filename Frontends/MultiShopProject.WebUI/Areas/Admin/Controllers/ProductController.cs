using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShopProject.Dto.CatalogDtos.ProductDtos;
using MultiShopProject.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopProject.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
//[AllowAnonymous]
[Route("Admin/Product")]
public class ProductController : Controller
{
    #region Old DI
    //private readonly IHttpClientFactory _httpClientFactory;
    //public ProductController(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}
    #endregion
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService; //ürünlerin kategorisi için.

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ProductViewBag();
        var values = await _productService.GetAllProductsAsync();
        return View(values);
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Products");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        //    return View(values);
        //}
        //return View();
        #endregion
    }

    [Route("CreateProduct")]
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {
        ProductViewBag();
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Categories"); // ürünlerin kategorilerini seçebilelim
        //var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        #endregion
        var values = await _categoryService.GetAllCategoriesAsync();
        List<SelectListItem> categoryValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
        ViewBag.CategoryValues = categoryValues;
        return View();
    }

    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(createProductDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
        //var responseMessage = await client.PostAsync("https://localhost:7192/api/Products", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Product", new { area = "Admin" });
        //}
        //return View();
        #endregion
        await _productService.CreateProductAsync(createProductDto);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.DeleteAsync("https://localhost:7192/api/Products?id=" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Product", new { area = "Admin" });
        //}
        //return View();
        #endregion
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        ProductViewBag();
        #region Old Method
        //var clientCategory = _httpClientFactory.CreateClient();
        //var responseMessageCategory = await clientCategory.GetAsync("https://localhost:7192/api/Categories"); // ürünlerin kategorilerini seçebilelim
        //var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
        //var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
        //List<SelectListItem> categoryValuesCategory = (from x in valuesCategory
        //                                               select new SelectListItem
        //                                               {
        //                                                   Text = x.CategoryName,
        //                                                   Value = x.CategoryID
        //                                               }).ToList();
        //ViewBag.CategoryValues = categoryValuesCategory;
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Products/" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
        //    return View(values);
        //}
        #endregion
        var values = await _categoryService.GetAllCategoriesAsync();
        List<SelectListItem> categoryValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();
        ViewBag.CategoryValues = categoryValues;
        var productValues = await _productService.GetByIdProductAsync(id);
        return View(productValues);
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(updateProductDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //var responseMessage = await client.PutAsync("https://localhost:7192/api/Products/", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Product", new { area = "Admin" });
        //}
        //return View();
        #endregion
        await _productService.UpdateProductAsync(updateProductDto);
        return RedirectToAction("Index", "Product", new { area = "Admin" });
    }

    [Route("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        ProductViewBag();

        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7192/api/Products/ProductListWithCategory");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        //    return View(values);
        //}

        return View();
    }

    public void ProductViewBag()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Listesi";
        ViewBag.v0 = "Ürün İşlemleri";
    }
}
