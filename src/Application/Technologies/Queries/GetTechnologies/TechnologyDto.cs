using CNode.Application.Common.Mappings;
using CNode.Domain.Entities;

namespace CNode.Application.Technologies.Queries.GetTechnologies
{
    public class TechnologyDto : IMapFrom<Technology>
    {
        public string Name { get; set; }
    }
}
