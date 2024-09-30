using MultiShopProject.Dto.OrderDtos.OrderOrderingDtos;

namespace MultiShopProject.WebUI.Services.OrderServices.OrderOrderingServices;

public interface IOrderOrderingService
{
    Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
}
