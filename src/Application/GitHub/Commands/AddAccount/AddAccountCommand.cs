using MediatR;

namespace CNode.Application.GitHub.Commands.AddAccount
{
    public class AddAccountCommand : IRequest<GitAccountDto>
    {
        public string Code { get; set; }
    }
}
