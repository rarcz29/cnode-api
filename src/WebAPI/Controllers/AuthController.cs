using System.Threading.Tasks;
using GitNode.Application.Auth.Commands.Login;
using GitNode.Application.Auth.Commands.Refresh;
using GitNode.Application.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebAPI.Controllers
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

        [HttpPost("refresh")]
        public async Task<ActionResult<RefreshTokenDto>> RefreshAsync([FromBody] RefreshCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
