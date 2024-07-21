﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopProject.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(createRegisterDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Register", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}