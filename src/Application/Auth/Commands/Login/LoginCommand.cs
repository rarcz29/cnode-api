using MediatR;

namespace CNode.Application.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthTokenDto>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
