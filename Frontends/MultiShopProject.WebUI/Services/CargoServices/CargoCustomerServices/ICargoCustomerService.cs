using MultiShopProject.Dto.CargoDtos.CargoCustomerDtos;

namespace MultiShopProject.WebUI.Services.CargoServices.CargoCustomerServices;

public interface ICargoCustomerService
{
    Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
}
