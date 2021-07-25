using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class GithubToken
    {
        public string access_token { get; } = "";
    }
}
