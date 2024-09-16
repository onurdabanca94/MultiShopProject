using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers;

public class PaymentController : Controller
{
    public IActionResult Index()
    {
        DirectoryList();
        return View();
    }
    public void DirectoryList()
    {
        ViewBag.directoryProject = "MultiShop Project";
        ViewBag.directoryMain = "Ödeme Ekranı";
        ViewBag.directoryProduct = "Kartla Ödeme";
    }
}
