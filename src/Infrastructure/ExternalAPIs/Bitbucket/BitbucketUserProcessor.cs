using System;
using System.Collections.Generic;
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

namespace GitNode.Infrastructure.ExternalAPIs.Bitbucket
{
    internal class BitbucketUserProcessor : BitbucketBase, IUserProcessor
    {
        private readonly IBitbucketOAuthProvider _bitbucket;

        public BitbucketUserProcessor(IAppHttpClient client, IBitbucketOAuthProvider options) : base(client)
        {
            _bitbucket = options;
        }

        public async Task<PlatformUser> GetUserAsync(string token)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.bitbucket.org/2.0/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await Client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketUser>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            using var response = await Client.ApiClient.GetAsync($"https://api.bitbucket.org/2.0/user");

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketUser>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.StatusCode.ToString());
        }

        public async Task<PlatformToken> GetTokenAsync(string code)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://bitbucket.org/site/oauth2/access_token");
            var authData = Encoding.ASCII.GetBytes($"{_bitbucket.Options.Key}:{_bitbucket.Options.Secret}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));
            var dict = new Dictionary<string, string>();
            dict.Add("code", code);
            dict.Add("grant_type", "authorization_code");
            requestMessage.Content = new FormUrlEncodedContent(dict);
            var response = await Client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketToken>();
                return Mapper.Map(model);
            }

            throw new ExternalApiException(response.ReasonPhrase);
        }
    }
}
