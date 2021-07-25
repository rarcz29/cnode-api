using GitNode.Application.Common.Mappings;
using GitNode.Domain.Entities;

namespace GitNode.Application.Auth.Commands.Login
{
    public class AuthTokenDto : IMapFrom<AuthenticationResult>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
