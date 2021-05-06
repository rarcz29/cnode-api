namespace CNode.Domain.Models
{
    public class GitRepository
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
        public bool @private { get; set; }
    }
}
