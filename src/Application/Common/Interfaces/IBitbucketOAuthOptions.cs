namespace GitNode.Application.Common.Interfaces
{
    public interface IBitbucketOAuthOptions
    {
        string Secret { get; }
        string Key { get; }
    }
}
