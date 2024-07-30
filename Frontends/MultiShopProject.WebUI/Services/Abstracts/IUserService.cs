using MultiShopProject.WebUI.Models;

namespace MultiShopProject.WebUI.Services.Abstracts;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
}
