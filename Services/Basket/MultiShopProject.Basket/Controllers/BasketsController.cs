using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Basket.Dtos;
using MultiShopProject.Basket.LoginServices;
using MultiShopProject.Basket.Services;

namespace MultiShopProject.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBasketDetail()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Basket changes has been saved!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Entire basket has been removed!");
        }
    }
}
