using System.Diagnostics.CodeAnalysis;

namespace GitNode.Infrastructure.ExternalAPIs.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class BitbucketUser
    {
        public string account_id { get; } = "";
        public string username { get; } = "";
        public BitbucketLinks links { get; } = new BitbucketLinks();

        public string nickname { get; } = "";
        //public string email { get; set; } // TODO: remove
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BitbucketLinks
    {
        public BitbucketHtml html { get; } = new BitbucketHtml();
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BitbucketHtml
    {
        public string href { get; } = "";
    }
}
