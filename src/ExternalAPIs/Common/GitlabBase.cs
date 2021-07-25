using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.ExternalAPIs.Interfaces;

namespace GitNode.ExternalAPIs.Common
{
    internal abstract class GitlabBase : ProcessorBase
    {
        protected IGitlabMapper _mapper;

        public GitlabBase(IAppHttpClient client) : base(client)
        {
            _mapper = MapperFactory.CreateGitlabMapper();
        }
    }
}
