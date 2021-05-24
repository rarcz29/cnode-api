using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Exceptions;
using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Common;
using CNode.ExternalAPIs.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitLab
{
    internal class GitlabRepoProcessor : GitlabBase, IRepoProcessor
    {
        public GitlabRepoProcessor(IAppHttpClient client) : base(client) { }

        public async Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, bool isPrivate, string token)
        {
            var json = JsonConvert.SerializeObject(new
            {
                name = reponame,
                description,
                visibility = isPrivate ? "private" : "public",
            });

            using var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://gitlab.com/api/v4/projects");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = data;

            var response = await _client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GitlabRepository>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }

        }
    }
}
