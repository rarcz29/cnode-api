using MediatR;

namespace GitNode.Application.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
