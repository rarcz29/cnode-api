using System.Diagnostics.CodeAnalysis;

namespace GitNode.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class GithubToken
    {
        public string access_token { get; } = "";
    }
}
