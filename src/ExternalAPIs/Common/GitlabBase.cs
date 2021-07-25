using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
{
    internal abstract class GitlabBase : ProcessorBase
    {
        protected readonly IGitlabMapper Mapper;

        public GitlabBase(IAppHttpClient client) : base(client)
        {
            Mapper = MapperFactory.CreateGitlabMapper();
        }
    }
}
