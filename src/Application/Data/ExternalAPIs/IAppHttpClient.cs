using System.Net.Http;

namespace CNode.Application.Data.ExternalAPIs
{
    public interface IAppHttpClient
    {
        HttpClient ApiClient { get; }
    }
}
