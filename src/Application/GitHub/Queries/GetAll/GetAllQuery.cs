using CNode.Application.Common.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CNode.Application.GitHub.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<PlatformAccountDto>>
    {
    }
}
