using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Mappings;
using MediatR;

namespace GitNode.Application.Platforms.Commands.AddAccount
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
