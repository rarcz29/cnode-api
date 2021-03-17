using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.ExternalAPIs.GitHub;

namespace CNode.ExternalAPIs
{
    class ProcessorsProvider : IProcessorsProvider
    {
        public ProcessorsProvider(IAppHttpClient client)
        {
            Account ??= new AccountProcessor(client);
            Users ??= new UserProcessor(client);
        }

        public IAccountProcessor Account { get; private set; }

        public IUserProcessor Users { get; private set; }
    }
}
