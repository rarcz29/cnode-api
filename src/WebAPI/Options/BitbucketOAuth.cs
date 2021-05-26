using CNode.Application.Common.Interfaces;

namespace CNode.WebAPI.Options
{
    public class BitbucketOAuth : IBitbucketOAuthOptions
    {
        public string Secret { get; set; }

        public string Key { get; set; }
    }
}
