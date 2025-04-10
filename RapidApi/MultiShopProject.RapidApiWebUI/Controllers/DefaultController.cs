using Microsoft.AspNetCore.Mvc;
using MultiShopProject.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShopProject.RapidApiWebUI.Controllers;

public class DefaultController : Controller
{
    public async Task<IActionResult> WeatherDetail()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/izmir"),
            Headers =
    {
        { "x-rapidapi-key", "17ae9dc694mshbe57104c2950c93p10bd74jsndef0685c3c40" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
            ViewBag.cityTemp = values.data.temp;
            return View();
        }
    }

    public async Task<IActionResult> Exchange()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
            Headers =
    {
        { "x-rapidapi-key", "17ae9dc694mshbe57104c2950c93p10bd74jsndef0685c3c40" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
            ViewBag.exchangeRateUsd = values.data.exchange_rate;
            ViewBag.previousRateUsd = values.data.previous_close;
        }

        var clientSecond = new HttpClient();
        var requestSecond = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
            Headers =
    {
        { "x-rapidapi-key", "17ae9dc694mshbe57104c2950c93p10bd74jsndef0685c3c40" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
        };
        using (var response = await clientSecond.SendAsync(requestSecond))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
            ViewBag.exchangeRateEuro = values.data.exchange_rate;
            ViewBag.previousRateEuro = values.data.previous_close;
            return View();
        }
    }
}
