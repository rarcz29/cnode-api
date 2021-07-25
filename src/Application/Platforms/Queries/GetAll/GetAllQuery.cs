using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.Data.Database;
using MediatR;

namespace GitNode.Application.Platforms.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<PlatformAccountDto>>, IPlatform
    {
        public GetAllQuery(string platform)
        {
            Platform = platform;
        }

        public string Platform { get; }
    }
    
    public class GetAllQueryHandler : PlatformHandlerBase,
        IRequestHandler<GetAllQuery, IEnumerable<PlatformAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlatformAccountDto>> Handle(GetAllQuery request,
            CancellationToken cancellationToken)
        {
            // TODO: exception handling
            var userId = int.Parse(_currentUser.UserId);
            var platform = await _unitOfWork.Platforms.GetByNameAsync(request.Platform);

            if (platform == null)
            {
                throw new UnknownPlatformException(BuildPlatformErrorMessage(request.Platform));
            }

            var accounts = await _unitOfWork.Accounts.FindAsync(x => x.PlatformId == platform.Id && x.UserId == userId);
            var dto = new List<PlatformAccountDto>();

            foreach (var account in accounts)
            {
                var reposDto = new List<PlatformRepositoryDto>();
                var repositories = await _unitOfWork.Repositories.GetRepositoriesFullAsync(account.Id);

                foreach (var repo in repositories)
                {
                    var tmpRepo = _mapper.Map<PlatformRepositoryDto>(repo);
                    reposDto.Add(tmpRepo);
                }

                // Automapper
                dto.Add(new PlatformAccountDto
                {
                    Login = account.Username,
                    OriginUrl = account.OriginUrl,
                    Repos = reposDto
                });
            }

            return dto;
        }
    }
}
