using GitNode.Application.Common.Interfaces.OAuth;

namespace GitNode.WebAPI.Options
{
    public class GitHubOAuth : IGitHubOAuthOptions
    {
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
    }
}
