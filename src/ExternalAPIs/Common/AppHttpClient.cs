using System.Net.Http;
using System.Net.Http.Headers;
using GitNode.Application.Common.Data.ExternalAPIs;

namespace GitNode.ExternalAPIs.Common
{
    internal class AppHttpClient : IAppHttpClient
    {
        public AppHttpClient()
        {
            ApiClient ??= new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.UserAgent.ParseAdd("gitnode");
        }

        public HttpClient ApiClient { get; private set; }
    }
}
