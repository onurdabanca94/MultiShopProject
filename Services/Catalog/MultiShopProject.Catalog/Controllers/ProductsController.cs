using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.ProductDtos;
using MultiShopProject.Catalog.Services.ProductServices;

namespace MultiShopProject.Catalog.Controllers
{
	//[AllowAnonymous]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _productService.GetAllProductsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(string id)
		{
			var values = await _productService.GetByIdProductAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productService.CreateProductAsync(createProductDto);
			return Ok("Product has been created!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProductAsync(id);
			return Ok("Product has been removed!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _productService.UpdateProductAsync(updateProductDto);
			return Ok("Product has been updated!");
		}

		[HttpGet("ProductListWithCategory")]
		public async Task<IActionResult> ProductListWithCategory()
		{
			var values = await _productService.GetProductsWithCategoryAsync();
			return Ok(values);
		}

		[HttpGet("ProductListWithCategoryByCategoryId")]
		public async Task<IActionResult> ProductListWithCategoryByCategoryId(string id)
		{
			var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
			return Ok(values);
		}
	}
}
