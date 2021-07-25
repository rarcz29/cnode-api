namespace GitNode.ExternalAPIs.Models
{
    public class GithubUser
    {
#pragma warning disable IDE1006 // Naming Styles

        public int id { get; set; }
        public string login { get; set; }
        public string html_url { get; set; }
        public string name { get; set; }
        //public string email { get; set; } // TODO: remove

#pragma warning restore IDE1006 // Naming Styles
    }
}
