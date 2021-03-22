using MediatR;

namespace CNode.Application.Auth.Queries.GetToken
{
    public class GetTokenQuery : IRequest<AuthTokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
