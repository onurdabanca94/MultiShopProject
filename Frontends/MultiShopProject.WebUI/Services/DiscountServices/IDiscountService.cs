using MultiShopProject.Dto.DiscountDtos;

namespace MultiShopProject.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    Task<int> GetDiscountCouponCountRate(string code);
}
