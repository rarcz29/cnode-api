using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Interfaces;
using CNode.Application.GitHub.Commands.CreateRepository;
using CNode.Domain.Entities;
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
            var github = await _unitOfWork.Platforms.GetByNameAsync("GitHub");
            //var token = await _unitOfWork.Accounts.GetTokenAsync(userId, github.Id, request.Username);
            var account = await _unitOfWork.Accounts.Get(userId, request.Username, github.Id);
            var repository = await _processors.Repositories.CreateNewRepoAsync(request.RepoName, request.Description, account.Token);

            var newRepo = new Repository
            {
                Name = request.RepoName,
                Description = request.Description,
                Private = repository.Private,
                Share = true, // TODO:
                OriginId = repository.Id.ToString(),
                OriginName = repository.Name,
                OriginUrl = repository.Url,
                AccountId = account.Id
            };

            _unitOfWork.Repositories.Add(newRepo);
            await _unitOfWork.SaveChangesAsync(); // TODO: exceptions
            return Unit.Value;
        }
    }
}
