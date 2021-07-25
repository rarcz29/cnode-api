using System.Threading.Tasks;
using GitNode.Application.Auth.Commands.Login;
using GitNode.Application.Users.Commands.RemoveUser;
using GitNode.Application.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut()]
        public async Task<ActionResult<AuthTokenDto>> UpdateUserDataAsync([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveUserAsync()
        {
            await _mediator.Send(new RemoveUserCommand());
            return Ok();
        }
    }
}
