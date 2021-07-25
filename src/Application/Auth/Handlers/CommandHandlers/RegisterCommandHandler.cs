using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Auth.Commands.Register;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Auth.Handlers.CommandHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUserManager _userManager;

        public RegisterCommandHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _userManager.RegisterAsync(request.Username, request.Email, request.Password);
            return Unit.Value;
        }
    }
}
