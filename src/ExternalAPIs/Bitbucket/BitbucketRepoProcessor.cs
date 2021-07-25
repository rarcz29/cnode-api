using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.ExternalAPIs;
using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Models;
using GitNode.ExternalAPIs.Common;
using GitNode.ExternalAPIs.Models;
using Newtonsoft.Json;

namespace GitNode.ExternalAPIs.Bitbucket
{
    internal class BitbucketRepoProcessor : BitbucketBase, IRepoProcessor
    {
        public BitbucketRepoProcessor(IAppHttpClient client) : base(client) { }

        public async Task<PlatformRepository> CreateNewRepoAsync(string reponame, string description, bool isPrivate, string token)
        {
            throw new NotImplementedException(); // TODO: implement

            var json = JsonConvert.SerializeObject(new { name = reponame, description, @private = isPrivate });
            using var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.github.com/user/repos");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = data;

            var response = await _client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketRepository>();
                return _mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }
    }
}
