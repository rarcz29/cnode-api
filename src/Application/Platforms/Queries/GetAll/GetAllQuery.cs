using System.Collections.Generic;
using GitNode.Application.Common.Dtos;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Platforms.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<PlatformAccountDto>>, IPlatform
    {
        public GetAllQuery(string platform)
        {
            Platform = platform;
        }

        public string Platform { get; }
    }
}
