using MultiShopProject.Dto.CatalogDtos.ProductDtos;

namespace MultiShopProject.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string id);
    Task<UpdateProductDto> GetByIdProductAsync(string id);
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
}
