using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopProject.IdentityServer.Models;
using System.Linq;

namespace MultiShopProject.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public StatisticsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult GetUserCount()
        {
            int userCount = _userManager.Users.Count();
            return Ok(userCount);
        }
    }
}
