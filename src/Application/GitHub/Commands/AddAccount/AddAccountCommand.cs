using CNode.Application.Common.Dtos;
using MediatR;

namespace CNode.Application.GitHub.Commands.AddAccount
{
    public class AddAccountCommand : IRequest<PlatformNewAccountDto>
    {
        public string Code { get; set; }
    }
}
