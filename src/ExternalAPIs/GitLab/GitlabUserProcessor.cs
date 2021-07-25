using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Common;
using GitNode.ExternalAPIs.Models;
using Newtonsoft.Json;

namespace GitNode.ExternalAPIs.GitLab
{
    internal class GitlabUserProcessor : GitlabBase, IUserProcessor
    {
        private readonly IGitLabOAuthProvider _gitlab;

        public GitlabUserProcessor(IAppHttpClient client, IGitLabOAuthProvider options) : base(client)
        {
            _gitlab = options;
        }

        public async Task<PlatformUser> GetUserAsync(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://gitlab.com/api/v4/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.ApiClient.SendAsync(requestMessage);

            var x = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GitlabUser>();
                return _mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            using var response = await _client.ApiClient.GetAsync($"https://gitlab.com/api/v4/users?username={username}");

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GitlabUser>();
                return _mapper.Map(model);
            }

            throw new ExternalApiException(response.StatusCode.ToString());
        }

        public async Task<PlatformToken> GetTokenAsync(string code)
        {
            // TODO: Create model and pass it as a parameter
            var json = JsonConvert.SerializeObject(new
            {
                code,
                client_secret = _gitlab.Options.Secret,
                client_id = _gitlab.Options.ApplicationID,
                grant_type = "authorization_code",
                redirect_uri = "https://localhost:3000"
            });

            using var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _client.ApiClient.PostAsync("https://gitlab.com/oauth/token", data);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<GitlabToken>();
                return _mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }
    }
}
