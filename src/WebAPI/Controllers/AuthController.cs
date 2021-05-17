using CNode.Application.Auth.Commands.Login;
using CNode.Application.Auth.Commands.Refresh;
using CNode.Application.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthTokenDto>> LoginAsync([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpDelete("logout")]
        //public async Task<IActionResult> LogoutAsync()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost("refresh")]
        public async Task<ActionResult<RefreshTokenDto>> RefreshAsync([FromBody] RefreshCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
