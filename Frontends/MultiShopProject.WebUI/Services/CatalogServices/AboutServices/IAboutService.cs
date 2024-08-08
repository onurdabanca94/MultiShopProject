using MultiShopProject.Dto.CatalogDtos.AboutDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutsAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
    Task<UpdateAboutDto> GetByIdAboutAsync(string id);
}
