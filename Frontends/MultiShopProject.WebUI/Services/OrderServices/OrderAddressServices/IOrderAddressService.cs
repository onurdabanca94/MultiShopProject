using MultiShopProject.Dto.OrderDtos.OrderAddressDtos;

namespace MultiShopProject.WebUI.Services.OrderServices.OrderAddressServices;

public interface IOrderAddressService
{
    //Task<List<ResultAboutDto>> GetAllAboutsAsync();
    Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    //Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    //Task DeleteAboutAsync(string id);
    //Task<UpdateAboutDto> GetByIdAboutAsync(string id);
}
