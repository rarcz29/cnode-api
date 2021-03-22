using MediatR;

namespace CNode.Application.GitHub.Commands
{
    public class CreateRepositoryCommand : IRequest
    {
        public string Username { get; set; }
        public string RepoName { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
    }
}
