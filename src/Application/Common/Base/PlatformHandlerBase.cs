using GitNode.Application.Common.Exceptions;
using GitNode.Application.Common.Interfaces.Data.ExternalAPIs;
using GitNode.Domain.Exceptions;

namespace GitNode.Application.Common.Base
{
    public abstract class PlatformHandlerBase
    {
        private readonly IProcessorsProvider _processors;

        protected PlatformHandlerBase() { }

        protected PlatformHandlerBase(IProcessorsProvider processors)
        {
            _processors = processors;
        }

        protected IPlatformProvider GetProcessor(string platform)
        {
            if (_processors == null)
            {
                throw new InternalServerException("Platform is not specified");
            }

            switch (platform.ToLower())
            {
                case "github":
                    return _processors.Github;
                case "bitbucket":
                    return _processors.Bitbucket;
                case "gitlab":
                    return _processors.Gitlab;
                default:
                    throw new UnknownPlatformException($"{platform} is not a valid platform name.");
            }
        }

        protected string BuildPlatformErrorMessage(string platform) => $"Server cannot find the {platform} in the database";
    }
}
