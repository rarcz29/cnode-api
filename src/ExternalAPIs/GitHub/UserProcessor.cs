using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Domain.Exceptions;
using CNode.Domain.Models;
using CNode.ExternalAPIs.Common;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitHub
{
    internal class UserProcessor : ProcessorBase, IUserProcessor
    {
        public UserProcessor(IAppHttpClient client) : base(client) { }

        public async Task<GitUser> GetUserAsync(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.ApiClient.SendAsync(requestMessage);

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
