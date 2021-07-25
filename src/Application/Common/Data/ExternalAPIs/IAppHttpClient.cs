using System.Net.Http;

namespace GitNode.Application.Common.Data.ExternalAPIs
{
    public interface IAppHttpClient
    {
        HttpClient ApiClient { get; }
    }
}
