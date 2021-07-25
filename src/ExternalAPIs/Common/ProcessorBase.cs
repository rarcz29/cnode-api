using GitNode.Application.Common.Data.ExternalAPIs;

namespace GitNode.ExternalAPIs.Common
{
    internal abstract class ProcessorBase
    {
        protected readonly IAppHttpClient _client;

        public ProcessorBase(IAppHttpClient client)
        {
            _client = client;
        }
    }
}
