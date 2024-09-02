﻿using MultiShopProject.Dto.CatalogDtos.ContactDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.ContactServices;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _httpClient.DeleteAsync("contacts?id=" + id);
    }
    public async Task<List<ResultContactDto>> GetAllContactsAsync()
    {
        var responseMessage = await _httpClient.GetAsync("contacts");
        var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
        return values;
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("contacts/" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
        return values;
    }
}
