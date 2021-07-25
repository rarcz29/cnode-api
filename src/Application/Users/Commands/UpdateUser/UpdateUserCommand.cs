using MediatR;

namespace GitNode.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
