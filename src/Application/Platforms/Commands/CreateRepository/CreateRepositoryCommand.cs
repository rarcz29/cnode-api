using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Mappings;
using MediatR;

namespace GitNode.Application.Platforms.Commands.CreateRepository
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
