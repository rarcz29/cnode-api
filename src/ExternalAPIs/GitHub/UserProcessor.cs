using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Domain.Exceptions;
using CNode.Domain.Models;
using CNode.ExternalAPIs.Common;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<GitUser> GetUserByUsernameAsync(string username)
        {
            using var response = await _client.ApiClient.GetAsync($"https://api.github.com/users/{username}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GitUser>();
            }
            else
            {
                throw new ExternalApiException(response.StatusCode.ToString());
            }
        }

        public async Task<AuthToken> GetTokenAsync(string code)
        {
            // TODO: Create model and pass it as a parameter
            var json = JsonConvert.SerializeObject(new { code = code, client_secret = "", client_id = "008d4433666f7d02672d" });
            using var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _client.ApiClient.PostAsync("https://github.com/login/oauth/access_token", data);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<AuthToken>();
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }
    }
}
