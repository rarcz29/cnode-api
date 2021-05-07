namespace CNode.ExternalAPIs.Models
{
    public class GithubRepository
    {
#pragma warning disable IDE1006 // Naming Styles

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
        public bool @private { get; set; }

#pragma warning restore IDE1006 // Naming Styles
    }
}
