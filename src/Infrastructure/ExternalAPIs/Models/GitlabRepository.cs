using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal abstract class GitlabRepository
    {
        public int id { get; } = 0;
        public string path { get; } = "";
        public string description { get; } = "";
        public string web_url { get; } = "";
        public string visibility { get; } = "";
    }
}
