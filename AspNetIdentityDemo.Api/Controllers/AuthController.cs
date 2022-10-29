using AspNetIdentityDemo.Api.Services;
using AspNetIdentityDemo.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AspNetIdentityDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        // private IMailService _mailService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
            // _mailService = mailService;
        }

        // "email": "user@example.com",
        // "password": "Bk.123"

        // api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result); // Status code: 200
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400

        }
        // api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = "Bk.123";
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    
                    return Ok(result); // Status code: 200
                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }
    }
}
