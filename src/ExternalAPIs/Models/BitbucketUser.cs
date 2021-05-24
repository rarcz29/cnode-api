namespace CNode.ExternalAPIs.Models
{
    public class BitbucketUser
    {
        public string account_id { get; set; }
        public string username { get; set; }
        public BitbucketLinks links { get; set; }
        public string nickname { get; set; }
        //public string email { get; set; } // TODO: remove
    }

    public class BitbucketLinks
    {
        public BitbucketHtml html { get; set; }
    }

    public class BitbucketHtml
    {
        public string href { get; set; }
    }
}
