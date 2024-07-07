using MultiShopProject.Catalog.Dtos.FeatureDtos;

namespace MultiShopProject.Catalog.Services.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task DeleteFeatureAsync(string id);
    Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
}
