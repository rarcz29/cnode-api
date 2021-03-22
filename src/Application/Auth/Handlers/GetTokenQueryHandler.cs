using CNode.Application.Auth.Queries.GetToken;
using CNode.Application.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Auth.Handlers
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, AuthTokenDto>
    {
        private readonly IUserManager _userManager;

        public GetTokenQueryHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthTokenDto> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var token = _userManager.Authenticate(request.Email, request.Password);
            // TODO: use automapper
            return new AuthTokenDto { Token = token, Type = "bearer"};
        }
    }
}
