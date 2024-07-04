using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShopProject.Dto.CatalogDtos.CategoryDtos;
using MultiShopProject.Dto.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
[Route("Admin/Product")]
public class ProductController : Controller
{

    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Listesi";
        ViewBag.v0 = "Ürün İşlemleri";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Products");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [Route("CreateProduct")]
    [HttpGet]
    public async Task<IActionResult> CreateProduct()
    {

        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Yeni Ürün Girişi";
        ViewBag.v0 = "Ürün İşlemleri";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Categories"); // ürünlerin kategorilerini seçebilelim
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
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
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
        var responseMessage = await client.PostAsync("https://localhost:7192/api/Products", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        return View();
    }

    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7192/api/Products?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Kategoriler";
        ViewBag.v3 = "Yeni Ürün Girişi";
        ViewBag.v0 = "Kategori İşlemleri";

        var clientCategory = _httpClientFactory.CreateClient();
        var responseMessageCategory = await clientCategory.GetAsync("https://localhost:7192/api/Categories"); // ürünlerin kategorilerini seçebilelim
        var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
        var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
        List<SelectListItem> categoryValuesCategory = (from x in valuesCategory
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryID
                                                       }).ToList();
        ViewBag.CategoryValues = categoryValuesCategory;


        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Products/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("UpdateProduct/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateProductDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7192/api/Products/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        return View();
    }

    [Route("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        ViewBag.v1 = "Ana Sayfa";
        ViewBag.v2 = "Ürünler";
        ViewBag.v3 = "Ürün Listesi";
        ViewBag.v0 = "Ürün İşlemleri";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7192/api/Products/ProductListWithCategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}
