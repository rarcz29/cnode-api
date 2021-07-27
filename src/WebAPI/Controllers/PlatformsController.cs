using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Platforms.Commands.AddAccount;
using GitNode.Application.Platforms.Commands.CreateRepository;
using GitNode.Application.Platforms.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class PlatformsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlatformsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("{platform}")]
        public async Task<ActionResult<PlatformNewAccountDto>> AddAccountAsync(
            [FromBody] AddAccountCommand request, [FromRoute] string platform)
        {
            var command = AddAccountExtendedCommand.FromCommand(request, platform, _mapper);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{platform}")]
        public async Task<ActionResult<IEnumerable<PlatformAccountDto>>> GetAllData([FromRoute] string platform)
        {
            var result = await _mediator.Send(new GetAllQuery(platform));
            return Ok(result);
        }

        [HttpPost("{platform}/repository")]
        public async Task<ActionResult<PlatformRepositoryDto>> CreateRepositoryAsync(
            [FromBody] CreateRepositoryCommand request, [FromRoute] string platform)
        {
            var command = CreateRepositoryExtendedCommand.FromCommand(request, platform, _mapper);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
