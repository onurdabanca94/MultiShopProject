using MultiShopProject.Dto.CatalogDtos.ContactDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactsAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(UpdateContactDto updateContactDto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}
