using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Infrastructure.ExternalAPIs.Interfaces;

namespace GitNode.Infrastructure.ExternalAPIs.Common
{
    internal abstract class GitlabBase : ProcessorBase
    {
        protected readonly IGitlabMapper Mapper;

        protected GitlabBase(IAppHttpClient client) : base(client)
        {
            Mapper = MapperFactory.CreateGitlabMapper();
        }
    }
}
