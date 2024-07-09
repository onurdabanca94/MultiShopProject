using MultiShopProject.Catalog.Dtos.BrandDtos;

namespace MultiShopProject.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task DeleteBrandAsync(string id);
    Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
}
