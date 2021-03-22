using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.ExternalAPIs.GitHub;

namespace CNode.ExternalAPIs
{
    class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client)
        {
            Users ??= new UserProcessor(client);
        }

        public IUserProcessor Users { get; private set; }
    }
}
