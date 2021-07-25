using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
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
