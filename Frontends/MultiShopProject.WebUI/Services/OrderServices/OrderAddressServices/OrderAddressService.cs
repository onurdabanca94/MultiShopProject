using MultiShopProject.Dto.OrderDtos.OrderAddressDtos;

namespace MultiShopProject.WebUI.Services.OrderServices.OrderAddressServices;

public class OrderAddressService : IOrderAddressService
{
    private readonly HttpClient _httpClient;

    public OrderAddressService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
    {
        await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createOrderAddressDto);
    }
}
