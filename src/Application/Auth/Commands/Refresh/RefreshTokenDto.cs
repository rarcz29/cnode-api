using GitNode.Application.Common.Mappings;
using GitNode.Domain.Entities;

namespace GitNode.Application.Auth.Commands.Refresh
{
    public class RefreshTokenDto : RefreshCommand, IMapFrom<AuthenticationResult>
    {
    }
}
