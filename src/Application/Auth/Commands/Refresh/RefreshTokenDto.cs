using CNode.Application.Common.Mappings;
using CNode.Domain.Entities;

namespace CNode.Application.Auth.Commands.Refresh
{
    public class RefreshTokenDto : RefreshCommand, IMapFrom<AuthenticationResult>
    {
    }
}
