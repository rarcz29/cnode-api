using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using CNode.Application.Common.Mappings;
using MediatR;

namespace CNode.Application.Platforms.Commands.AddAccount
{
    public class AddAccountCommand : AddAccount,
                                     IRequest<PlatformNewAccountDto>,
                                     IMapFrom<AddAccount>,
                                     IPlatform
    {
        public AddAccountCommand() { }

        public AddAccountCommand(string platform)
        {
            Platform = platform;
        }

        public string Platform { get; set; }
    }
}
