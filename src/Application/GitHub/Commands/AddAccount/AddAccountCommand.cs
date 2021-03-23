using MediatR;

namespace CNode.Application.GitHub.Commands.AddAccount
{
    public class AddAccountCommand : IRequest
    {
        public string Code { get; set; }
    }
}
