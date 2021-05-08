using CNode.Application.Common.Mappings;
using CNode.Domain.Entities;

namespace CNode.Application.Common.Dtos
{
    public class PlatformRepositoryDto : IMapFrom<Repository>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OriginUrl { get; set; }
        public bool Private { get; set; }
    }
}
