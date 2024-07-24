using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.BrandDtos;
using MultiShopProject.Catalog.Services.BrandServices;

namespace MultiShopProject.Catalog.Controllers
{
	//[AllowAnonymous] -- Authentication olmadan giriş
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandService _brandService;
		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _brandService.GetAllBrandsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrandById(string id)
		{
			var values = await _brandService.GetByIdBrandAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
			await _brandService.CreateBrandAsync(createBrandDto);
			return Ok("Brand has been created!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return Ok("Brand has been updated!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);
			return Ok("Brand has been removed!");
		}
	}
}
