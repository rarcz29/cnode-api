using MediatR;
using System.Collections.Generic;

namespace CNode.Application.Technologies.Queries.GetTechnologies
{
    public class GetTechnologiesQuery : IRequest<IEnumerable<TechnologyDto>>
    {
        public string Pattern { get; set; }
    }
}
