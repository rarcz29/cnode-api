using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Identity;
using CNode.Application.V1.GitHub;
using CNode.Domain.Entities;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProcessorsProvider _processors;
        private readonly ICurrentUserService _currentUser;

        public GitHubController(IUnitOfWork unitOfWork,
                                IProcessorsProvider processors,
                                ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _processors = processors;
            _currentUser = currentUser;
        }

        [HttpPost("auth/account")]
        public async Task<IActionResult> SaveTokenAsync([FromBody] AuthRequestDto request)
        {
            var userId = int.Parse(_currentUser.UserId);
            var token = await _processors.Users.GetTokenAsync(request.Code);
            var github = await _unitOfWork.GitTools.GetByNameAsync("GitHub");
            var user = await _processors.Users.GetUserAsync(token.access_token);

            var newAccount = new GitAccount
            {
                GitUserId = user.id,
                UserId = userId,
                Token = token.access_token,
                GitToolId = github.Id
            };

            _unitOfWork.GitAccounts.Add(newAccount);
            var affected = await _unitOfWork.SaveChangesAsync();
            return affected == 1
                // TODO: dto
                ? Ok(new { UserId = newAccount.Id, Login = user.login })
                : BadRequest();
        }

        [HttpPost("repository")]
        public async Task<IActionResult> CreateRepository([FromBody] CreateRepositoryDto request)
        {
            var userId = int.Parse(_currentUser.UserId);
            var token = await GetUserTokenAsync(userId, request.Username);
            await _processors.Repositories.CreateNewRepoAsync(request.RepoName, request.Description, token);
            return Ok();
        }

        private async Task<string> GetUserTokenAsync(int userId, string username)
        {
            var github = await _unitOfWork.GitTools.GetByNameAsync("GitHub");
            var user = await _processors.Users.GetUserByUsernameAsync(username);
            var token = await _unitOfWork.GitAccounts.GetTokenAsync(userId, github.Id, user.id);
            return token;
        }
    }
}
