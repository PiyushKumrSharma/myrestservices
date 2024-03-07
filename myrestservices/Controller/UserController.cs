using myrestservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace myrestservices.Controller
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [BasicAuthentication("username", "password")]
        public async Task<IActionResult> GetRandomUser()
        {
            var user = await _userService.GetRandomUserAsync();
            return Ok(user);
        }
    }
}
