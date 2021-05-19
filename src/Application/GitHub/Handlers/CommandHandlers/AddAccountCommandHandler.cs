using AutoMapper;
using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using CNode.Application.GitHub.Commands.AddAccount;
using CNode.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.GitHub.Handlers.CommandHandlers
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, PlatformNewAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly IProcessorsProvider _processors;
        private readonly IMapper _mapper;

        public AddAccountCommandHandler(IUnitOfWork unitOfWork,
                                        ICurrentUserService currentUser,
                                        IProcessorsProvider processors,
                                        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _processors = processors;
            _mapper = mapper;
        }

        public async Task<PlatformNewAccountDto> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            // exceptions
            var userId = int.Parse(_currentUser.UserId);
            var token = await _processors.Users.GetTokenAsync(request.Code);
            var github = await _unitOfWork.Platforms.GetByNameAsync("GitHub");
            var user = await _processors.Users.GetUserAsync(token.AccessToken);

            var newAccount = new Account
            {
                OriginId = user.Id,
                OriginUrl = user.Url,
                UserId = userId,
                PlatformId = github.Id,
                Username = user.Login,
                Token = token.AccessToken
            };

            _unitOfWork.Accounts.Add(newAccount);
            await _unitOfWork.SaveChangesAsync();
            // TODO: automapper
            return new PlatformNewAccountDto
            {
                Login = newAccount.Username,
                OriginUrl = newAccount.OriginUrl
            };
        }
    }
}
