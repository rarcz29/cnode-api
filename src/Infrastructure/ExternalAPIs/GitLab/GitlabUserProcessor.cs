using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Common.Interfaces.Data.ExternalAPIs;
using GitNode.Application.Common.Interfaces.OAuth;
using GitNode.Domain.Platforms;
using GitNode.Infrastructure.ExternalAPIs.Common;
using GitNode.Infrastructure.ExternalAPIs.Models;
using Newtonsoft.Json;

namespace GitNode.Infrastructure.ExternalAPIs.GitLab
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
            var response = await Client.ApiClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode) throw new ExternalApiException(response.ReasonPhrase);
            
            var model = await response.Content.ReadAsAsync<GitlabUser>();
            return Mapper.Map(model);
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            using var response = await Client.ApiClient.GetAsync($"https://gitlab.com/api/v4/users?username={username}");

            if (!response.IsSuccessStatusCode) throw new ExternalApiException(response.StatusCode.ToString());
            
            var model = await response.Content.ReadAsAsync<GitlabUser>();
            return Mapper.Map(model);
        }

        public async Task<PlatformToken> GetTokenAsync(string code)
        {
            // TODO: Create model and pass it as a parameter
            var json = JsonConvert.SerializeObject(new
            {
                code,
                client_secret = _gitlab.Options.Secret,
                client_id = _gitlab.Options.ApplicationId,
                grant_type = "authorization_code",
                redirect_uri = "https://localhost:3000"
            });

            using var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await Client.ApiClient.PostAsync("https://gitlab.com/oauth/token", data);

            if (!response.IsSuccessStatusCode) throw new ExternalApiException(response.ReasonPhrase);
            
            var model = await response.Content.ReadAsAsync<GitlabToken>();
            return Mapper.Map(model);
        }
    }
}
