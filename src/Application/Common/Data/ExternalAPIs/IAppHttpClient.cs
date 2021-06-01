using System.Net.Http;

namespace CNode.Application.Common.Data.ExternalAPIs
{
    public interface IAppHttpClient
    {
        HttpClient ApiClient { get; }
    }
}
