using CNode.Application.Common.Mappings;
using CNode.Domain.Entities;

namespace CNode.Application.Auth.Commands.Login
{
    public class AuthTokenDto : IMapFrom<AuthenticationResult>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
