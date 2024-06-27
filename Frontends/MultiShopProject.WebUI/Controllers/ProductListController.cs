using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
