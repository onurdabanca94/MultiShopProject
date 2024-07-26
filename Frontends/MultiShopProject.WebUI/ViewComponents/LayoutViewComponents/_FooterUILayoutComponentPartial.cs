using Microsoft.AspNetCore.Mvc;
using MultiShopProject.Dto.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace MultiShopProject.WebUI.ViewComponents.LayoutViewComponents;

public class _FooterUILayoutComponentPartial : ViewComponent
{

    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {

        string token = "";
        using (var httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5001/connect/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id","MultiShopProjectVisitorId" },
                        {"client_secret","multishopprojectsecret" },
                        {"grant_type","client_credentials" }
                    })
            };

            using (var response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonObject.Parse(content);
                    token = tokenResponse["access_token"].ToString();
                }
            }
        }

        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var responseMessage = await client.GetAsync("https://localhost:7192/api/Abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            return View(values);
        }

        return View();
    }
}
