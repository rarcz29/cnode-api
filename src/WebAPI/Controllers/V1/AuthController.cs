using CNode.Application.Auth.Queries.GetToken;
using CNode.Application.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMediator _mediator;

        public AuthController(IUserManager userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken([FromQuery] GetTokenQuery query)
        {
            var result = _mediator.Send(query);
            return Ok(result);
            //var token = _userManager.Authenticate(email, password);
            //return token != null
            //    // TODO: create dto's
            //    ? Ok(new { Token = token, Type = "bearer" })
            //    : Unauthorized(new { Message = "Wrong email or password"});
        }
    }
}
