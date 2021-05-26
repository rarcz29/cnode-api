using AutoMapper;
using CNode.Application.Common.Dtos;
using CNode.Application.Platforms.Commands.AddAccount;
using CNode.Application.Platforms.Commands.CreateRepository;
using CNode.Application.Platforms.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers
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
        public async Task<ActionResult<PlatformNewAccountDto>> AddAccountAsync([FromBody] AddAccount request,
                                                                               [FromRoute] string platform)
        {
            var command = _mapper.Map<AddAccountCommand>(request);
            command.Platform = platform;
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
        public async Task<ActionResult<PlatformRepositoryDto>> CreateRepositoryAsync([FromBody] CreateRepository request,
                                                                                     [FromRoute] string platform)
        {
            var command = _mapper.Map<CreateRepositoryCommand>(request);
            command.Platform = platform;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
