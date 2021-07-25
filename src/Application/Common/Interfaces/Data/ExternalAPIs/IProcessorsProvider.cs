namespace GitNode.Application.Common.Interfaces.Data.ExternalAPIs
{
    public interface IProcessorsProvider
    {
        IPlatformProvider Github { get; }

        IPlatformProvider Bitbucket { get; }

        IPlatformProvider Gitlab { get; }
    }
}
