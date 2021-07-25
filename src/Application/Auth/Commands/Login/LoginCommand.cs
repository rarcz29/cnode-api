using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthTokenDto>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    
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
