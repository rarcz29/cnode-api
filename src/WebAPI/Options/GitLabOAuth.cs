using GitNode.Application.Common.Interfaces.OAuth;

namespace GitNode.WebAPI.Options
{
    public class GitLabOAuth : IGitLabOAuthOptions
    {
        public string ApplicationId { get; set; }

        public string Secret { get; set; }
    }
}
