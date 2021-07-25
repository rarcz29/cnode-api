namespace GitNode.Application.Common.Data.ExternalAPIs
{
    public interface IPlatformProvider
    {
        IUserProcessor Users { get; }

        IRepoProcessor Repositories { get; }
    }
}
