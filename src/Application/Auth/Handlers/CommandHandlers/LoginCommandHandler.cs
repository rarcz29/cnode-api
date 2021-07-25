using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Auth.Commands.Login;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Auth.Handlers.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthTokenDto>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AuthTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.AuthenticateAsync(request.UsernameOrEmail, request.Password);
            return _mapper.Map<AuthTokenDto>(result);
        }
    }
}
