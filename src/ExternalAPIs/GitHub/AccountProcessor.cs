using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Domain.Exceptions;
using CNode.Domain.Models;
using CNode.ExternalAPIs.Common;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.GitHub
{
    class AccountProcessor : ProcessorBase, IAccountProcessor
    {
        public AccountProcessor(IAppHttpClient client) : base(client) { }

        public async Task<AuthToken> GetTokenAsync(string code)
        {
            var json = JsonConvert.SerializeObject(new { code = code, client_secret = "", client_id = "" });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

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

