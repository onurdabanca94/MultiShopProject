using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            //var user = User.Claims;
            DirectoryList();
            return View();
        }

        public void DirectoryList()
        {
            ViewBag.directoryProject = "MultiShop Project";
            ViewBag.directoryMain = "Ana Sayfa";
            ViewBag.directoryProduct = "Ürün Listesi";
        }
    }
}
