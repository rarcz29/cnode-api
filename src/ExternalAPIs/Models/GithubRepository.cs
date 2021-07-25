using System.Diagnostics.CodeAnalysis;

namespace GitNode.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class GithubRepository
    {
        public int id { get; } = 0;
        public string name { get; } = "";
        public string description { get; } = "";
        public string html_url { get; } = "";
        public bool @private { get; } = true;
    }
}
