namespace CNode.Application.V1.GitHub
{
    public class CreateRepositoryDto
    {
        public string Username { get; set; }
        public string RepoName { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
    }
}
