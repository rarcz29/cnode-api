using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Interfaces;
using CNode.Application.Common.Models;
using CNode.Domain.Exceptions;
using CNode.ExternalAPIs.Common;
using CNode.ExternalAPIs.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitHub
{
    internal class UserProcessor : GithubBase, IUserProcessor
    {
        private readonly IGitHubOAuthProvider _github;

        public UserProcessor(IAppHttpClient client, IGitHubOAuthProvider options) : base(client)
        {
            _github = options;
        }

        public async Task<PlatformUser> GetUserAsync(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubUser>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            using var response = await _client.ApiClient.GetAsync($"https://api.github.com/users/{username}");

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubUser>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.StatusCode.ToString());
            }
        }

        public async Task<PlatformToken> GetTokenAsync(string code)
        {
            // TODO: Create model and pass it as a parameter
            var json = JsonConvert.SerializeObject(new { code, client_secret = _github.Options.ClientSecret, client_id = _github.Options.ClientID });
            using var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _client.ApiClient.PostAsync("https://github.com/login/oauth/access_token", data);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GithubToken>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }
    }
}
