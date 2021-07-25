namespace GitNode.Application.Common.Interfaces.OAuth
{
    public interface IBitbucketOAuthOptions
    {
        string Secret { get; }
        string Key { get; }
    }
}
