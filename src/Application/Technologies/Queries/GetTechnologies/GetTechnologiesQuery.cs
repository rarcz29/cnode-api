using System.Collections.Generic;
using GitNode.Application.Common.Dtos;
using MediatR;

namespace GitNode.Application.Technologies.Queries.GetTechnologies
{
    public class GetTechnologiesQuery : IRequest<IEnumerable<TechnologyDto>>
    {
        public string Pattern { get; set; }
    }
}
