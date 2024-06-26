using MultiShopProject.Basket.Dtos;

namespace MultiShopProject.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}
