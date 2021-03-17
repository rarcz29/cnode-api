using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Domain.Exceptions;
using CNode.Domain.Models;
using CNode.ExternalAPIs.Common;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitHub
{
    internal class UserProcessor : ProcessorBase, IUserProcessor
    {
        public UserProcessor(IAppHttpClient client) : base(client) { }

        public async Task<GitUser> GetUserAsync(string username)
        {
            using var response = await _client.ApiClient.GetAsync($"https://api.github.com/users/{username}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GitUser>();
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }
    }
}
