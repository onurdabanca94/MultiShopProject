using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.FeatureSliderDtos;
using MultiShopProject.Catalog.Services.FeatureSliderSerives;

namespace MultiShopProject.Catalog.Controllers;

//[AllowAnonymous]
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FeatureSlidersController : ControllerBase
{
	private readonly IFeatureSliderService _featureSliderService;
	public FeatureSlidersController(IFeatureSliderService featureSliderService)
	{
		_featureSliderService = featureSliderService;
	}

	[HttpGet]
	public async Task<IActionResult> FeatureSliderList()
	{
		var values = await _featureSliderService.GetAllFeatureSliderAsync();
		return Ok(values);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetFeatureSliderById(string id)
	{
		var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
		return Ok(values);
	}

	[HttpPost]
	public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
	{
		await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
		return Ok("Feature Slider has been created!");
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteFeatureSlider(string id)
	{
		await _featureSliderService.DeleteFeatureSliderAsync(id);
		return Ok("Feature Slider has been removed!");
	}

	[HttpPut]
	public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
	{
		await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
		return Ok("Feature Slider has been updated!");
	}
}
