using Microsoft.AspNetCore.Mvc;

namespace MultiShopProject.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			var user = User.Claims;
			return View();
		}
	}
}
