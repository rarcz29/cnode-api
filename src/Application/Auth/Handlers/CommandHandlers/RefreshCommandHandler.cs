using CNode.Application.Auth.Commands.Refresh;
using CNode.Application.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Auth.Handlers.CommandHandlers
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshTokenDto>
    {
        private readonly IUserManager _userManager;

        public RefreshCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<RefreshTokenDto> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            //var response = await _userManager.RefreshAsync(request.Token, request.RefreshToken);
            // TODO: use automapper
            return new RefreshTokenDto { Token = "", RefreshToken = "" };
        }
    }
}
