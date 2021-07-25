using System.Collections.Generic;
using GitNode.Application.Common.Mappings;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Dtos
{
    public class PlatformRepositoryDto : IMapFrom<Repository>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OriginUrl { get; set; }
        public bool Private { get; set; }
        public IEnumerable<TechnologyDto> Technologies { get; set; }
    }
}
