namespace GitNode.Application.Common.Interfaces
{
    public interface IGitHubOAuthOptions
    {
        string ClientSecret { get; }
        string ClientId { get; }
    }
}
