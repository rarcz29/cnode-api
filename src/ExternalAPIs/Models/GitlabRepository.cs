namespace CNode.ExternalAPIs.Models
{
    internal class GitlabRepository
    {
        public int id { get; set; }
        public string path { get; set; }
        public string description { get; set; }
        public string web_url { get; set; }
        public string visibility { get; set; }
    }
}
