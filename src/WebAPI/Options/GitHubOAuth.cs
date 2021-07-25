using GitNode.Application.Common.Interfaces;

namespace GitNode.WebAPI.Options
{
    public class GitHubOAuth : IGitHubOAuthOptions
    {
        public string ClientSecret { get; set; }
        public string ClientID { get; set; }
    }
}
