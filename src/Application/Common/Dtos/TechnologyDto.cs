using CNode.Application.Common.Mappings;
using CNode.Domain.Entities;

namespace CNode.Application.Common.Dtos
{
    public class TechnologyDto : IMapFrom<Technology>
    {
        public string Name { get; set; }
    }
}
