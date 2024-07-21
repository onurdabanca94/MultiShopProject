﻿using AutoMapper;
using MongoDB.Driver;
using MultiShopProject.Catalog.Dtos.ContactDtos;
using MultiShopProject.Catalog.Entities;
using MultiShopProject.Catalog.Settings;

namespace MultiShopProject.Catalog.Services.ContactServices;

public class ContactService : IContactService
{
    private readonly IMongoCollection<Contact> _contactCollection;
    private readonly IMapper _mapper;

    public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        //MongoDb için veritabanı ilişkisi sırasıyla Bağlantı -> Database -> Tablo olarak alt alta gelecektir.
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        _mapper = mapper;

    }
    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        var value = _mapper.Map<Contact>(createContactDto);
        await _contactCollection.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
    }

    public async Task<List<ResultContactDto>> GetAllContactsAsync()
    {
        var values = await _contactCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultContactDto>>(values);
    }

    public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
    {
        var values = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdContactDto>(values);
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
        var values = _mapper.Map<Contact>(updateContactDto);
        await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
    }
}
