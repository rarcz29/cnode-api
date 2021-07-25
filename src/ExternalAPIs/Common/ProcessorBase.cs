using GitNode.Application.Common.Data.ExternalAPIs;

namespace GitNode.ExternalAPIs.Common
{
    internal abstract class ProcessorBase
    {
        protected readonly IAppHttpClient Client;

        public ProcessorBase(IAppHttpClient client)
        {
            Client = client;
        }
    }
}
