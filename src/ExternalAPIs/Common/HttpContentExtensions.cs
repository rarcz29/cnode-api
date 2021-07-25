using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitNode.ExternalAPIs.Common
{
    internal static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content) =>
            await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync());
    }
}
