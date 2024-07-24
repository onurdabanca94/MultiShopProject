using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Catalog.Dtos.ContactDtos;
using MultiShopProject.Catalog.Services.ContactServices;

namespace MultiShopProject.Catalog.Controllers
{
	//[AllowAnonymous]
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactsController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			var values = await _contactService.GetAllContactsAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetContactById(string id)
		{
			var values = await _contactService.GetByIdContactAsync(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			await _contactService.CreateContactAsync(createContactDto);
			return Ok("Contact has been created!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteContact(string id)
		{
			await _contactService.DeleteCategoryAsync(id);
			return Ok("Contact has been removed!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			await _contactService.UpdateContactAsync(updateContactDto);
			return Ok("Contact has been updated!");
		}
	}
}
