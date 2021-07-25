namespace GitNode.Application.Common.Interfaces.Data.ExternalAPIs
{
    public interface IPlatformProvider
    {
        IUserProcessor Users { get; }

        IRepoProcessor Repositories { get; }
    }
}
