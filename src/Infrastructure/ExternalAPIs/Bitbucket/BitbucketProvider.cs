using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces.OAuth;

namespace GitNode.Infrastructure.ExternalAPIs.Bitbucket
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
