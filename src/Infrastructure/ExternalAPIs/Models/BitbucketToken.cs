using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BitbucketToken
    {
        public string access_token { get; } = "";
    }
}
