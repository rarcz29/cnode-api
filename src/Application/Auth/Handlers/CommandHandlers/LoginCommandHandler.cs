using CNode.Application.Auth.Commands.Login;
using CNode.Application.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Auth.Handlers.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthTokenDto>
    {
        private readonly IUserManager _userManager;

        public LoginCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _userManager.AuthenticateAsync(request.Username, request.Email, request.Password);
            // TODO: use automapper
            return new AuthTokenDto { Token = token, Type = "bearer" };
        }
    }
}
