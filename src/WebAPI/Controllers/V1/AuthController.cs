using CNode.Application.Auth.Commands.Login;
using CNode.Application.Auth.Queries.GetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result?.Token != null
                ? Ok(result)
                : BadRequest();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync()
        {
            throw new NotImplementedException();
        }
    }
}
