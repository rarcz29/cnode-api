using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Base;
using GitNode.Application.Common.Data.Database;
using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Platforms.Commands.AddAccount;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Platforms.Handlers.CommandHandlers
{
    public class AddAccountCommandHandler : PlatformHandlerBase,
        IRequestHandler<AddAccountCommand, PlatformNewAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public AddAccountCommandHandler(IUnitOfWork unitOfWork,
                                        ICurrentUserService currentUser,
                                        IProcessorsProvider processors)
                                        : base(processors)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<PlatformNewAccountDto> Handle(AddAccountCommand request,
                                                        CancellationToken cancellationToken)
        {
            var processor = GetProcessor(request.Platform);
            // exceptions
            var userId = int.Parse(_currentUser.UserId);
            var token = await processor.Users.GetTokenAsync(request.Code);
            var user = await processor.Users.GetUserAsync(token.AccessToken);
            var platform = await _unitOfWork.Platforms.GetByNameAsync(request.Platform);

            if (platform == null)
            {
                throw new UnknownPlatformException(BuildPlatformErrorMessage(request.Platform));
            }

            var newAccount = new Account
            {
                OriginId = user.Id,
                OriginUrl = user.Url,
                UserId = userId,
                PlatformId = platform.Id,
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
