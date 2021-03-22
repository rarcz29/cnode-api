using CNode.Application.GitHub.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GitHubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("auth/account")]
        public async Task<IActionResult> SaveTokenAsync([FromBody] AddAccountCommand command)
        {
            await _mediator.Send(command);
            return Ok(); // TODO: return success info
        }

        [HttpPost("repository")]
        public async Task<IActionResult> CreateRepository([FromBody] CreateRepositoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
