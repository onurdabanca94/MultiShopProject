using MultiShopProject.WebUI.Models;
using MultiShopProject.WebUI.Services.Abstracts;

namespace MultiShopProject.WebUI.Services.Concretes;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
    }
}
