using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Identity;
using CNode.Application.GitHub.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.GitHub.Handlers.CommandHandlers
{
    class CreateRepositoryCommandHandler : IRequestHandler<CreateRepositoryCommand>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProcessorsProvider _processors;

        public CreateRepositoryCommandHandler(ICurrentUserService currentUser,
                                              IUnitOfWork unitOfWork,
                                              IProcessorsProvider processors)
        {
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
            _processors = processors;
        }

        public async Task<Unit> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(_currentUser.UserId);
            var github = await _unitOfWork.GitTools.GetByNameAsync("GitHub");
            var user = await _processors.Users.GetUserByUsernameAsync(request.Username);
            var token = await _unitOfWork.GitAccounts.GetTokenAsync(userId, github.Id, user.id);
            await _processors.Repositories.CreateNewRepoAsync(request.RepoName, request.Description, token);
            return Unit.Value;
        }
    }
}
