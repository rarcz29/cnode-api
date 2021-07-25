namespace GitNode.Application.Common.Interfaces.OAuth
{
    public interface IGitLabOAuthOptions
    {
        string ApplicationId { get; }

        string Secret { get; }
    }
}
