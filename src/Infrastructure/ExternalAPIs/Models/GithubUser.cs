using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class GithubUser
    {
        public int id { get; } = 0;
        public string login { get; } = "";
        public string html_url { get; } = "";
        public string name { get; } = "";
        //public string email { get; set; } // TODO: remove
    }
}
