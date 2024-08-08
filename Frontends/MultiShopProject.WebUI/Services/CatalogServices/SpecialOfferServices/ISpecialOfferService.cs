using MultiShopProject.Dto.CatalogDtos.SpecialOfferDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
}
