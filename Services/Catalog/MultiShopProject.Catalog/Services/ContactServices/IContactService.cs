using MultiShopProject.Catalog.Dtos.ContactDtos;

namespace MultiShopProject.Catalog.Services.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactsAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task UpdateContactAsync(UpdateContactDto updateContactDto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdContactDto> GetByIdContactAsync(string id);
}
