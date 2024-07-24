using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.FeatureDtos;
using MultiShopProject.Catalog.Services.FeatureServices;

namespace MultiShopProject.Catalog.Controllers
{
	//[AllowAnonymous]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureService _featureService;

		public FeaturesController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await _featureService.GetAllFeaturesAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureById(string id)
		{
			var values = await _featureService.GetByIdFeatureAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return Ok("Feature has been created!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteFeatureAsync(id);
			return Ok("Feature has been removed!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);
			return Ok("Feature has been updated!");
		}
	}
}
