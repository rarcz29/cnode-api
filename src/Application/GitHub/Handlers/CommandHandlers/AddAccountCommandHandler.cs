using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Identity;
using CNode.Application.GitHub.Commands;
using CNode.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.GitHub.Handlers.CommandHandlers
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly IProcessorsProvider _processors;

        public AddAccountCommandHandler(IUnitOfWork unitOfWork,
                                        ICurrentUserService currentUser,
                                        IProcessorsProvider processors)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _processors = processors;
        }

        // TODO: exceptions
        public async Task<Unit> Handle(AddAccountCommand request, CancellationToken cancellationToken)
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
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
