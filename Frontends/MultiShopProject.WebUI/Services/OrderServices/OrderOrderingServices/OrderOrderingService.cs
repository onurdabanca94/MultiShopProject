using MultiShopProject.Dto.OrderDtos.OrderOrderingDtos;

namespace MultiShopProject.WebUI.Services.OrderServices.OrderOrderingServices;

public class OrderOrderingService : IOrderOrderingService
{
    private readonly HttpClient _httpClient;

    public OrderOrderingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
    {
        var responseMessage = await _httpClient.GetAsync("orders/GetOrderingByUserId?id=" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();
        return values;
    }
}
