using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Discount.Dtos;
using MultiShopProject.Discount.Services;

namespace MultiShopProject.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var values = await _discountService.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Coupon has been created!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Coupon has been deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Coupon has been updated!");
        }

        [HttpGet("GetDiscountCouponCountRate")]
        public IActionResult GetDiscountCouponCountRate(string code)
        {
            var values = _discountService.GetDiscountCouponCountRate(code);
            return Ok(values);
        }
    }
}

//public int GetDiscountCouponCountRate(string code)