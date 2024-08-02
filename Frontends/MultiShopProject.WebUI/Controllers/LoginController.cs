using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.IdentityDtos.LoginDtos;
using MultiShopProject.WebUI.Services;
using MultiShopProject.WebUI.Services.Abstracts;

namespace MultiShopProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            //_loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #region Old Method
        //[HttpPost]
        //public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        //{

        //    return View();
        //}
        #endregion
        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }

        //[HttpPost]
        //public async Task<IActionResult> SignIn(SignInDto signInDto)
        //{
        //    signInDto.Username = "onur01";
        //    signInDto.Password = "1111aA*";
        //    await _identityService.SignIn(signInDto);
        //    return RedirectToAction("Index", "User");
        //}
    }
}
