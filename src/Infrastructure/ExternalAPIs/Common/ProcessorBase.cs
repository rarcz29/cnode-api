using GitNode.Application.Common.Interfaces.Data.ExternalAPIs;

namespace GitNode.Infrastructure.ExternalAPIs.Common
{
    internal abstract class ProcessorBase
    {
        protected readonly IAppHttpClient Client;

        protected ProcessorBase(IAppHttpClient client)
        {
            Client = client;
        }
    }
}
