using System.Threading.Tasks;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Technologies.Queries.GetTechnologies;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GitNode.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnologiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnologiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<TechnologyDto>> GetTechnologies([FromQuery] GetTechnologiesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
