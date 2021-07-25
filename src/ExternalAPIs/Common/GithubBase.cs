using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
{
    internal class GithubBase : ProcessorBase
    {
        protected readonly IGithubMapper Mapper;

        public GithubBase(IAppHttpClient client) : base (client)
        {
            Mapper = MapperFactory.CreateGithubMapper();
        }
    }
}
