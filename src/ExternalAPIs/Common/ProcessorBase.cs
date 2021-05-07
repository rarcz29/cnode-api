using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Interfaces;

namespace CNode.ExternalAPIs.Common
{
    internal abstract class ProcessorBase
    {
        protected readonly IAppHttpClient _client;
        protected readonly IGitHubOAuthProvider _github;

        public ProcessorBase(IAppHttpClient client, IGitHubOAuthProvider options)
        {
            _client = client;
            _github = options;
        }
    }
}
