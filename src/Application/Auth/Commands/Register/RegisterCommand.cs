using MediatR;

namespace CNode.Application.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
