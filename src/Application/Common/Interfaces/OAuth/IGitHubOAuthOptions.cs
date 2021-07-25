namespace GitNode.Application.Common.Interfaces.OAuth
{
    public interface IGitHubOAuthOptions
    {
        string ClientSecret { get; }
        string ClientId { get; }
    }
}
