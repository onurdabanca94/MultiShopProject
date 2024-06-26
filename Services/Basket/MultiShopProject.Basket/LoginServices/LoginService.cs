namespace MultiShopProject.Basket.LoginServices;

public class LoginService : ILoginService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginService(IHttpContextAccessor contextAccessor)
    {
        _httpContextAccessor = contextAccessor;
    }

    public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value; //sub'in içerisinde Id var ve bunu token'dan alıcaz. Bu sebeple sepetle ilişkilendirilecek.
}
