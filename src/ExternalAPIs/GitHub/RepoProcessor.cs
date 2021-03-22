using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Domain.Exceptions;
using CNode.ExternalAPIs.Common;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitHub
{
    internal class RepoProcessor : ProcessorBase, IRepoProcessor
    {
        public RepoProcessor(IAppHttpClient client) : base(client) { }

        // TODO: return response
        public async Task CreateNewRepoAsync(string reponame, string description, string token)
        {
            var json = JsonConvert.SerializeObject(new { name = reponame, description = description });
            using var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.github.com/user/repos");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("token", token);
            requestMessage.Content = data;

            var response = await _client.ApiClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            var code = response.StatusCode;

            if (!response.IsSuccessStatusCode)
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }
    }
}
