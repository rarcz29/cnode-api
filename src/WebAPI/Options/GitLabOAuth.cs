using CNode.Application.Common.Interfaces;

namespace CNode.WebAPI.Options
{
    public class GitLabOAuth : IGitLabOAuthOptions
    {
        public string ApplicationID { get; set; }

        public string Secret { get; set; }
    }
}
