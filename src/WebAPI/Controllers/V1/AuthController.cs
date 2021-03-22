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
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken([FromQuery] GetTokenQuery query)
        {
            var result = await _mediator.Send(query);
            return result?.Token != null
                ? Ok(result)
                : BadRequest();
        }
    }
}
