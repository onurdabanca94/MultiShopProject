using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        //private readonly ICategoryService _categoryService;

        //public UILayoutController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}
        public IActionResult _UILayout()
        {
            return View();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}
