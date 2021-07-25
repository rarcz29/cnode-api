using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Domain.Platforms;
using GitNode.Infrastructure.ExternalAPIs.Common;
using GitNode.Infrastructure.ExternalAPIs.Models;
using Newtonsoft.Json;

namespace GitNode.Infrastructure.ExternalAPIs.GitHub
{
    internal class GithubUserProcessor : GithubBase, IUserProcessor
    {
        private readonly IGitHubOAuthProvider _github;

        public GithubUserProcessor(IAppHttpClient client, IGitHubOAuthProvider options) : base(client)
        {
            _github = options;
        }

        public async Task<PlatformUser> GetUserAsync(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubUser>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            using var response = await Client.ApiClient.GetAsync($"https://api.github.com/users/{username}");

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubUser>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.StatusCode.ToString());
        }

        public async Task<PlatformToken> GetTokenAsync(string code)
        {
            // TODO: Create model and pass it as a parameter
            var json = JsonConvert.SerializeObject(new { code, client_secret = _github.Options.ClientSecret, client_id = _github.Options.ClientId });
            using var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await Client.ApiClient.PostAsync("https://github.com/login/oauth/access_token", data);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubToken>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }
    }
}
