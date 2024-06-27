using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
