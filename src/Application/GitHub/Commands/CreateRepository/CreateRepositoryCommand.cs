using CNode.Application.Common.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CNode.Application.GitHub.Commands.CreateRepository
{
    public class CreateRepositoryCommand : IRequest<PlatformRepositoryDto>
    {
        public string Username { get; set; }
        public string RepoName { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public IEnumerable<string> Technologies { get; set; }
    }
}
