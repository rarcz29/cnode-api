using System;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Domain.Platforms;
using GitNode.Infrastructure.ExternalAPIs.Common;

namespace GitNode.Infrastructure.ExternalAPIs.Bitbucket
{
    internal class BitbucketRepoProcessor : BitbucketBase, IRepoProcessor
    {
        public BitbucketRepoProcessor(IAppHttpClient client) : base(client) { }

        public async Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, bool isPrivate, string token)
        {
            throw new NotImplementedException(); // TODO: implement
        }
    }
}
