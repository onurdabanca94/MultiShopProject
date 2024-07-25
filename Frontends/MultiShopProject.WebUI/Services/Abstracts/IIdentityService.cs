using MultiShopProject.Dto.IdentityDtos.LoginDtos;

namespace MultiShopProject.WebUI.Services.Abstracts;

public interface IIdentityService
{
    Task<bool> SignIn(SignInDto signInDto);
}
