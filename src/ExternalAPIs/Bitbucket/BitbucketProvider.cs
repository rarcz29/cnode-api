using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Interfaces;

namespace CNode.ExternalAPIs.Bitbucket
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
