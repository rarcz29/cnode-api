using CNode.Application.Common.Interfaces;

namespace CNode.WebAPI.Options
{
    public class GitHubOAuth : IGitHubOAuthOptions
    {
        public string ClientSecret { get; set; }
        public string ClientID { get; set; }
    }
}
