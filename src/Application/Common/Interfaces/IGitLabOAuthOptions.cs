namespace GitNode.Application.Common.Interfaces
{
    public interface IGitLabOAuthOptions
    {
        string ApplicationId { get; }

        string Secret { get; }
    }
}
