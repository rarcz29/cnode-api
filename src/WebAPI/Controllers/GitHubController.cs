using CNode.Application.GitHub.Commands.AddAccount;
using CNode.Application.GitHub.Commands.CreateRepository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GitHubController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("auth/account")]
        public async Task<IActionResult> AddAccountAsync([FromBody] AddAccountCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("repository")]
        public async Task<IActionResult> CreateRepositoryAsync([FromBody] CreateRepositoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
