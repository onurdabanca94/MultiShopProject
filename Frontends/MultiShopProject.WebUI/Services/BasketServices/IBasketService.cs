﻿using MultiShopProject.Dto.BasketDtos;

namespace MultiShopProject.WebUI.Services.BasketServices;

public interface IBasketService
{
	Task<BasketTotalDto> GetBasket();
	Task SaveBasket(BasketTotalDto basketTotalDto);
	Task DeleteBasket(string userId);
	Task AddBasketItem(BasketItemDto basketItemDto);
	Task<bool> RemoveBasketItem(string productId);
}
