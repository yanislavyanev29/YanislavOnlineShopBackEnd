using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using YanislavOnlineShopBackEnd.CustomExceptions;
using YanislavOnlineShopBackEnd.Services;

namespace YanislavOnlineShopBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
                _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {


            try
            {
                var result = await _userService.SignUp(user);
                return Created("", result);

            }
            catch (UsernameAlreadyExists e)
            {

                return StatusCode(409, e.Message);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            try
            {
                var result = await _userService.SignIn(user);
                return Created("", result);
            }
            catch (InvalidUsernameOrPasswordException e)
            {
                return StatusCode(401, e.Message);
            }

        }
    }
}
