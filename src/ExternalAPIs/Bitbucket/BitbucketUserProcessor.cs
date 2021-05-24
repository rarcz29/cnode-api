using CNode.Application.Common.Data.ExternalAPIs;
using CNode.Application.Common.Data.ExternalAPIs.GitHub;
using CNode.Application.Common.Exceptions;
using CNode.Application.Common.Interfaces;
using CNode.Application.Common.Models;
using CNode.ExternalAPIs.Common;
using CNode.ExternalAPIs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CNode.ExternalAPIs.Bitbucket
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
            //throw new NotImplementedException(); // TODO: implement

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.bitbucket.org/2.0/user");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.ApiClient.SendAsync(requestMessage);

            var x = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketUser>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }

        public async Task<PlatformUser> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException(); // TODO: implement

            using var response = await _client.ApiClient.GetAsync($"https://api.bitbucket.org/2.0/user");

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketUser>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.StatusCode.ToString());
            }
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
            var response = await _client.ApiClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<BitbucketToken>();
                return _mapper.Map(model);
            }
            else
            {
                throw new ExternalApiException(response.ReasonPhrase);
            }
        }
    }
}
