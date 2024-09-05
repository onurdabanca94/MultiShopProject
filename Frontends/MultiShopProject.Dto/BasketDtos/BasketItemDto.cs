﻿namespace MultiShopProject.Dto.BasketDtos;

public class BasketItemDto
{
	public string ProductId { get; set; } //verileri catalog mikroservisinden çekeceğiz ve oradaki Id değer tipi string
	public string ProductName { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
