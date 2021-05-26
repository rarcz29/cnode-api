using CNode.Application.Common.Data.ExternalAPIs;
using CNode.ExternalAPIs.Interfaces;

namespace CNode.ExternalAPIs.Common
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
