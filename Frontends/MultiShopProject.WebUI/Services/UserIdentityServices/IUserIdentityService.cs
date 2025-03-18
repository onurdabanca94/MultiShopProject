using MultiShopProject.Dto.IdentityDtos.UserDtos;

namespace MultiShopProject.WebUI.Services.UserIdentityServices;

public interface IUserIdentityService
{
    Task<List<ResultUserDto>> GetAllUserListAsync();
}
