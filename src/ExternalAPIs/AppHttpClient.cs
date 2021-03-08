using CNode.Application.Data.ExternalAPIs;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CNode.ExternalAPIs
{
    internal class AppHttpClient : IAppHttpClient
    {
        public AppHttpClient()
        {
            ApiClient ??= new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            ApiClient.DefaultRequestHeaders.UserAgent.TryParseAdd("cnode");
        }

        public HttpClient ApiClient { get; private set; }
    }
}
