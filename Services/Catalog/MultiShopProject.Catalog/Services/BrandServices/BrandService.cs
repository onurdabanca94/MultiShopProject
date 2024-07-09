using AutoMapper;
using MongoDB.Driver;
using MultiShopProject.Catalog.Dtos.BrandDtos;
using MultiShopProject.Catalog.Entities;
using MultiShopProject.Catalog.Settings;

namespace MultiShopProject.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brandCollection;
    private readonly IMapper _mapper;

    public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        //MongoDb için veritabanı ilişkisi sırasıyla Bağlantı -> Database -> Tablo olarak alt alta gelecektir.
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        _mapper = mapper;

    }
    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        var values = _mapper.Map<Brand>(createBrandDto);
        await _brandCollection.InsertOneAsync(values);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _brandCollection.DeleteOneAsync(x => x.BrandId == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
    {
        var values = await _brandCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultBrandDto>>(values);
    }

    public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
    {
        var values = await _brandCollection.Find<Brand>(x => x.BrandId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdBrandDto>(values);
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        var values = _mapper.Map<Brand>(updateBrandDto);
        await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == updateBrandDto.BrandId, values);
    }
}
