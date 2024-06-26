using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
