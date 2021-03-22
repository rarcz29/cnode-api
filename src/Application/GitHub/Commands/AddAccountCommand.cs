using MediatR;

namespace CNode.Application.GitHub.Commands
{
    public class AddAccountCommand : IRequest
    {
        public string Code { get; set; }
    }
}
