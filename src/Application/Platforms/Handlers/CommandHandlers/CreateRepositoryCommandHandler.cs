using CNode.Application.Common.Base;
using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Dtos;
using CNode.Application.Common.Exceptions;
using CNode.Application.Common.Interfaces;
using CNode.Application.Platforms.Commands.CreateRepository;
using CNode.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Platforms.Handlers.CommandHandlers
{
    class CreateRepositoryCommandHandler : PlatformHandlerBase,
        IRequestHandler<CreateRepositoryCommand, PlatformRepositoryDto>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRepositoryCommandHandler(ICurrentUserService currentUser,
                                              IUnitOfWork unitOfWork,
                                              IProcessorsProvider processors)
                                              : base(processors)
        {
            _currentUser = currentUser;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlatformRepositoryDto> Handle(CreateRepositoryCommand request, CancellationToken cancellationToken)
        {
            var processor = GetProcessor(request.Platform);
            var userId = int.Parse(_currentUser.UserId);
            var platform = await _unitOfWork.Platforms.GetByNameAsync(request.Platform);

            if (platform == null)
            {
                throw new UnknownPlatformException(BuildPlatformErrorMessage(request.Platform));
            }

            var account = await _unitOfWork.Accounts.Get(userId, request.Username, platform.Id);
            var repository = await processor.Repositories.CreateNewRepoAsync(request.RepoName, request.Description, request.Private, account.Token);
            var technologies = await _unitOfWork.Technologies.GetTechnologiesAsync(request.Technologies);

            var newRepo = new Repository
            {
                Name = repository.Name,
                Description = repository.Description,
                Private = repository.Private,
                Share = true, // TODO:
                OriginId = repository.Id.ToString(),
                OriginName = repository.Name,
                OriginUrl = repository.Url,
                AccountId = account.Id,
                Technologies = technologies?.ToList(),
            };

            _unitOfWork.Repositories.Add(newRepo);
            await _unitOfWork.SaveChangesAsync(); // TODO: exceptions
            // TODO: automapper
            return new PlatformRepositoryDto
            {
                Name = newRepo.Name,
                Description = newRepo.Description,
                Private = newRepo.Private,
                OriginUrl = newRepo.OriginUrl
            };
        }
    }
}
