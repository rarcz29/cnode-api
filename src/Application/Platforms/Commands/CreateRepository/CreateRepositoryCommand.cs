using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using CNode.Application.Common.Mappings;
using MediatR;

namespace CNode.Application.Platforms.Commands.CreateRepository
{
    public class CreateRepositoryCommand : CreateRepository,
                                           IRequest<PlatformRepositoryDto>,
                                           IMapFrom<CreateRepository>,
                                           IPlatform
    {
        public CreateRepositoryCommand() { }

        public CreateRepositoryCommand(string platform)
        {
            Platform = platform;
        }

        public string Platform { get; set; }
    }
}
