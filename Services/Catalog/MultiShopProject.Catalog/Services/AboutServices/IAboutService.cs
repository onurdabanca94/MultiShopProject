using MultiShopProject.Catalog.Dtos.AboutDto;

namespace MultiShopProject.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutsAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
    Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
}
