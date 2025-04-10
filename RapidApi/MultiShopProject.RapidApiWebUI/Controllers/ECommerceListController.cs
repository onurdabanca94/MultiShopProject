using Microsoft.AspNetCore.Mvc;
using MultiShopProject.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShopProject.RapidApiWebUI.Controllers;

public class ECommerceListController : Controller
{
    public async Task<IActionResult> ECommerceList()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=logitech%20fare&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
            Headers =
    {
        { "x-rapidapi-key", "17ae9dc694mshbe57104c2950c93p10bd74jsndef0685c3c40" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ECommerceViewModel.Rootobject>(body);
            return View(values.data.products.ToList());
        }
    }
}