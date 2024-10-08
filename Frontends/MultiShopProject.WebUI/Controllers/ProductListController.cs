﻿using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShopProject.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            DirectoryList();
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            DirectoryListDetail();
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.ProductId = "66849d20cd7a0ecad830471a";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Content olarak atanan, bu contentin hangi dil desteği, mediatorün ne olduğu.
            var responseMessage = await client.PostAsync("https://localhost:7170/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }

        public void DirectoryList()
        {
            ViewBag.directoryMain = "Ana Sayfa";
            ViewBag.directoryProduct = "Ürünler";
            ViewBag.directoryProductList = "Ürün Listesi";
        }
        public void DirectoryListDetail()
        {
            ViewBag.directoryMain = "Ana Sayfa";
            ViewBag.directoryProductList = "Ürün Listesi";
            ViewBag.directoryProductDetail = "Ürün Detayları";
        }
    }
}
