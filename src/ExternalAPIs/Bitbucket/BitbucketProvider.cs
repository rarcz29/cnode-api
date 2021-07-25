using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces;

namespace GitNode.ExternalAPIs.Bitbucket
{
    internal class BitbucketProvider : IPlatformProvider
    {
        public BitbucketProvider(IAppHttpClient client, IBitbucketOAuthProvider options)
        {
            Users ??= new BitbucketUserProcessor(client, options);
            Repositories ??= new BitbucketRepoProcessor(client);
        }

        public IUserProcessor Users { get; }

        public IRepoProcessor Repositories { get; }
    }
}
