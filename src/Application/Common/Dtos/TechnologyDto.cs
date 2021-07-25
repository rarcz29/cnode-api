using GitNode.Application.Common.Mappings;
using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Dtos
{
    public class TechnologyDto : IMapFrom<Technology>
    {
        public string Name { get; set; }
    }
}
