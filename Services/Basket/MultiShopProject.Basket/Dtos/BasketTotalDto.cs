namespace MultiShopProject.Basket.Dtos;

public class BasketTotalDto
{
    public string UserId { get; set; } //UserId IdentityServer'da tutuluyor. Sepet -> Sepetin kullanıcısının id'sine göre belirleniyor.
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; } //Her zaman indirim kodu belirtilmeyebilir. --nullable yapılabilir.
    public List<BasketItemDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
}
