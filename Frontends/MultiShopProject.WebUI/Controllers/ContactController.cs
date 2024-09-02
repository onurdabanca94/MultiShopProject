using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.ContactDtos;
using MultiShopProject.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShopProject.WebUI.Controllers;

public class ContactController : Controller
{
    //private readonly IHttpClientFactory _httpClientFactory;
    private readonly IContactService _contactService;

    public ContactController(/*IHttpClientFactory httpClientFactory,*/ IContactService contactService)
    {
        //_httpClientFactory = httpClientFactory;
        _contactService = contactService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        DirectoryList();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto createContactDto)
    {
        createContactDto.IsRead = false;
        createContactDto.SendDate = DateTime.Now;
        await _contactService.CreateContactAsync(createContactDto);
        return RedirectToAction("Index", "Default");

        #region Old Method
        //createContactDto.IsRead = false;
        //createContactDto.SendDate = DateTime.Now;
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(createContactDto);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
        //var responseMessage = await client.PostAsync("https://localhost:7192/api/Contacts", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Default");
        //}

        //return View();
        #endregion
    }

    public void DirectoryList()
    {
        ViewBag.directoryProject = "MultiShop Project";
        ViewBag.directoryMain = "İletişim";
        ViewBag.directoryProduct = "Mesaj Gönder";
    }
}
