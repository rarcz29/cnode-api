using CNode.Application.Data.ExternalAPIs;

namespace CNode.ExternalAPIs.Common
{
    internal abstract class ProcessorBase
    {
        protected readonly IAppHttpClient _client;

        public ProcessorBase(IAppHttpClient client) => _client = client;
    }
}
