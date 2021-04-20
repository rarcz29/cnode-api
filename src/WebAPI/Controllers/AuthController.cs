using CNode.Application.Auth.Commands.Login;
using CNode.Application.Auth.Commands.Refresh;
using CNode.Application.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            throw new Exception("Exception test");
            var result = await _mediator.Send(command);
            return result?.Token != null
                ? Ok(result)
                : BadRequest();
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
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
