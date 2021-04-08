using MediatR;

namespace CNode.Application.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthTokenDto>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
