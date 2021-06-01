using CNode.Application.Common.Dtos;
using CNode.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace CNode.Application.Platforms.Queries.GetAll
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
