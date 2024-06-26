using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
