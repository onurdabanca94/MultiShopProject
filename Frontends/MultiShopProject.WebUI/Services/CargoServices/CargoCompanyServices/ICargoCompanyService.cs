using MultiShopProject.Dto.CargoDtos.CargoCompanyDtos;

namespace MultiShopProject.WebUI.Services.CargoServices.CargoCompanyServices;

public interface ICargoCompanyService
{
    Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync();
    Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
    Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
    Task DeleteCargoCompanyAsync(int id);
    Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id);
}
