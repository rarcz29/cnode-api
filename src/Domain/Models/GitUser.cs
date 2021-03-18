namespace CNode.Domain.Models
{
    public class GitUser
    {
        // TODO: snake case
        public int id { get; set; }
        public string login { get; set; }
        public string html_url { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
