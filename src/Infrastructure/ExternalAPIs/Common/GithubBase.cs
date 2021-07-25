using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Infrastructure.ExternalAPIs.Interfaces;

namespace GitNode.Infrastructure.ExternalAPIs.Common
{
    internal class GithubBase : ProcessorBase
    {
        protected readonly IGithubMapper Mapper;

        protected GithubBase(IAppHttpClient client) : base (client)
        {
            Mapper = MapperFactory.CreateGithubMapper();
        }
    }
}
