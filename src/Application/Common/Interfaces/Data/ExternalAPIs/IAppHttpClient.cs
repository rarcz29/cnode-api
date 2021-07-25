using System.Net.Http;

namespace GitNode.Application.Common.Interfaces.Data.ExternalAPIs
{
    public interface IAppHttpClient
    {
        HttpClient ApiClient { get; }
    }
}
