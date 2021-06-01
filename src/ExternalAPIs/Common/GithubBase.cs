using CNode.Application.Common.Data.ExternalAPIs;
using CNode.ExternalAPIs.Interfaces;

namespace CNode.ExternalAPIs.Common
{
    internal class GithubBase : ProcessorBase
    {
        protected IGithubMapper _mapper;

        public GithubBase(IAppHttpClient client) : base (client)
        {
            _mapper = MapperFactory.CreateGithubMapper();
        }
    }
}
