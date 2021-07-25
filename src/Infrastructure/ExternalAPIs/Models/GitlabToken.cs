using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal abstract class GitlabToken
    {
        public string access_token { get; } = "";
        public string refresh_token { get; } = "";
    }
}
