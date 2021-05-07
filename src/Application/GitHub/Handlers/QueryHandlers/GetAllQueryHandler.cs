using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using CNode.Application.GitHub.Queries.GetAll;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.GitHub.Handlers.QueryHandlers
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<PlatformAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<IEnumerable<PlatformAccountDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            // TODO: exception handling
            var userId = int.Parse(_currentUser.UserId);
            var platform = await _unitOfWork.Platforms.GetByNameAsync("GitHub");
            var accounts = await _unitOfWork.Accounts.FindAsync(x => x.PlatformId == platform.Id && x.UserId == userId);
            var dto = new List<PlatformAccountDto>();
            var reposDto = new List<RepositoryDto>();

            foreach (var account in accounts)
            {
                var repositories = await _unitOfWork.Repositories.FindAsync(x => x.AccountId == account.Id);

                foreach (var repo in repositories)
                {
                    // TODO: Automapper
                    reposDto.Add(new RepositoryDto
                    {
                        Name = repo.Name,
                        Descritption = repo.Description,
                        OriginUrl = repo.OriginUrl,
                        Private = repo.Private
                    });
                }

                dto.Add(new PlatformAccountDto
                {
                    Name = account.Username,
                    Repos = reposDto
                });
            }

            return dto;
        }
    }
}
