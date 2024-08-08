using MultiShopProject.Dto.CatalogDtos.FeatureDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task DeleteFeatureAsync(string id);
    Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
}
