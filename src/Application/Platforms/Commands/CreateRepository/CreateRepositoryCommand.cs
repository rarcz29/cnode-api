using System.Collections.Generic;

namespace GitNode.Application.Platforms.Commands.CreateRepository
{
    public class CreateRepository
    {
        public string Username { get; set; }
        public string RepoName { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public IEnumerable<string> Technologies { get; set; }
    }
}
