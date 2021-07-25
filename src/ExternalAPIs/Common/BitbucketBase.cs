using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
{
    class BitbucketBase : ProcessorBase
    {
        protected readonly IBitbucketMapper Mapper;

        public BitbucketBase(IAppHttpClient client) : base(client)
        {
            Mapper = MapperFactory.CreateBitbucketMapper();
        }
    }
}
