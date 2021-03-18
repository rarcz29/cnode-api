using CNode.Application.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CNode.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AuthController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("token")]
        public IActionResult GetToken([FromQuery] string email, [FromQuery] string password)
        {
            var token = _userManager.Authenticate(email, password);
            return token != null
                // TODO: create dto's
                ? Ok(new { Token = token, Type = "bearer" })
                : Unauthorized(new { Message = "Wrong email or password"});
        }
    }
}
