using CNode.Application.Auth.Commands.Register;
using CNode.Application.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Auth.Handlers.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUserManager _userManager;

        public RegisterCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // TODO: vallidation
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _userManager.RegisterAsync(request.Username, request.Email, request.Password, request.TwoFactorEnabled);
            return Unit.Value;
        }
    }
}
