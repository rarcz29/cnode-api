using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Infrastructure.ExternalAPIs.Interfaces;

namespace GitNode.Infrastructure.ExternalAPIs.Common
{
    class BitbucketBase : ProcessorBase
    {
        protected readonly IBitbucketMapper Mapper;

        protected BitbucketBase(IAppHttpClient client) : base(client)
        {
            Mapper = MapperFactory.CreateBitbucketMapper();
        }
    }
}
