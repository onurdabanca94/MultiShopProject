using Microsoft.AspNetCore.Mvc;
using MultiShopProject.WebUI.Services.CommentServices;

namespace MultiShopProject.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailReviewComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ICommentService _commentService;

    public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory, ICommentService commentService)
    {
        _httpClientFactory = httpClientFactory;
        _commentService = commentService;
    }
    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var values = await _commentService.CommentListByProductId(id);
        return View(values);

        #region Old Method
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7170/api/Comments/CommentListByProductId?id=" + id);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        //    return View(values);
        //}

        //return View();
        #endregion
    }
}
