using CNode.Application.Data.ExternalAPIs;
using CNode.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IProcessorsProvider _processors;

        public UsersController(IProcessorsProvider processors)
        {
            _processors = processors;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<GitUser>> GetUser([FromRoute] string username)
        {
            var user = await _processors.Users.GetUserAsync(username);
            return Ok(user);
        }
    }
}
