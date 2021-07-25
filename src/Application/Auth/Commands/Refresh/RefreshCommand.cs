using MediatR;

namespace GitNode.Application.Auth.Commands.Refresh
{
    public class RefreshCommand : IRequest<RefreshTokenDto>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
