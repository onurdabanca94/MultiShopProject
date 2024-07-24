using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.AboutDto;
using MultiShopProject.Catalog.Services.AboutServices;

namespace MultiShopProject.Catalog.Controllers
{
	//[AllowAnonymous]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly IAboutService _aboutService;

		public AboutsController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public async Task<IActionResult> AboutList()
		{
			var values = await _aboutService.GetAllAboutsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAbout(string id)
		{
			var values = await _aboutService.GetByIdAboutAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{
			await _aboutService.CreateAboutAsync(createAboutDto);
			return Ok("About has been created!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			await _aboutService.UpdateAboutAsync(updateAboutDto);
			return Ok("About has been updated!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteAbout(string id)
		{
			await _aboutService.DeleteAboutAsync(id);
			return Ok("About has been removed!");
		}
	}
}
