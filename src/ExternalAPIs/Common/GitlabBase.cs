using CNode.Application.Common.Data.ExternalAPIs;
using CNode.ExternalAPIs.Interfaces;

namespace CNode.ExternalAPIs.Common
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
