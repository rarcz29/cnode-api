using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
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
