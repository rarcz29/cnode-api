using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
{
    class BitbucketBase : ProcessorBase
    {
        protected IBitbucketMapper _mapper;

        public BitbucketBase(IAppHttpClient client) : base(client)
        {
            _mapper = MapperFactory.CreateBitbucketMapper();
        }
    }
}
