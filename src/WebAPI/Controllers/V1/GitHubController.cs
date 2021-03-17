using CNode.Application.Common.Data.ExternalAPIs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CNode.WebAPI.Controllers.V1
{
    // TODO: move to the application layer
    public class CodeRequestDto
    {
        public string Code { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IProcessorsProvider _processors;

        public GitHubController(IProcessorsProvider processors)
        {
            _processors = processors;
        }

        [HttpPost("auth/account")]
        public async Task<IActionResult> SaveTokenAsync([FromBody] CodeRequestDto request)
        {
            var token = await _processors.Account.GetTokenAsync(request.Code);
            return Ok(token);
        }
    }
}
