using MediatR;

namespace CNode.Application.GitHub.Commands.CreateRepository
{
    public class CreateRepositoryCommand : IRequest
    {
        public string Username { get; set; }
        public string RepoName { get; set; }
        public string Description { get; set; }
    }
}
