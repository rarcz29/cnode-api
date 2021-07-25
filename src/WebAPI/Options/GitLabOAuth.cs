using GitNode.Application.Common.Interfaces;

namespace GitNode.WebAPI.Options
{
    public class GitLabOAuth : IGitLabOAuthOptions
    {
        public string ApplicationID { get; set; }

        public string Secret { get; set; }
    }
}
