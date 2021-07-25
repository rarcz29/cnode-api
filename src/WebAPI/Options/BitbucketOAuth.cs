using GitNode.Application.Common.Interfaces;

namespace GitNode.WebAPI.Options
{
    public class BitbucketOAuth : IBitbucketOAuthOptions
    {
        public string Secret { get; set; }

        public string Key { get; set; }
    }
}
