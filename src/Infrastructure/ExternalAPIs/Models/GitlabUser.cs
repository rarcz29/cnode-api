using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal abstract class GitlabUser
    {
        public int id { get; } = 0;
        public string username { get; } = "";
        public string web_url { get; } = "";
        public string name { get; } = "";
    }
}
