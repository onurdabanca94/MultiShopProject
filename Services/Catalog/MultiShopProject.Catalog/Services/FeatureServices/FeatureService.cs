﻿using AutoMapper;
using MongoDB.Driver;
using MultiShopProject.Catalog.Dtos.FeatureDtos;
using MultiShopProject.Catalog.Entities;
using MultiShopProject.Catalog.Settings;

namespace MultiShopProject.Catalog.Services.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly IMongoCollection<Feature> _featureCollection;
    private readonly IMapper _mapper;

    public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        //MongoDb için veritabanı ilişkisi sırasıyla Bağlantı -> Database -> Tablo olarak alt alta gelecektir.
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
        _mapper = mapper;

    }
    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        var value = _mapper.Map<Feature>(createFeatureDto);
        await _featureCollection.InsertOneAsync(value);
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
    {
        var values = await _featureCollection.Find<Feature>(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureDto>>(values);
    }

    public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
    {
        var values = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdFeatureDto>(values);
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        var values = _mapper.Map<Feature>(updateFeatureDto);
        await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
    }
}
