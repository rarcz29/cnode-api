using CNode.Application.Data.ExternalAPIs;
using CNode.Application.Data.ExternalAPIs.GitHub;
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
