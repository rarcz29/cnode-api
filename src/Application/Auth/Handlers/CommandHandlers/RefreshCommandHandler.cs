using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GitNode.Application.Auth.Commands.Refresh;
using GitNode.Application.Common.Interfaces;
using MediatR;

namespace GitNode.Application.Auth.Handlers.CommandHandlers
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshTokenDto>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public RefreshCommandHandler(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RefreshTokenDto> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.RefreshAsync(request.Token, request.RefreshToken);
            return _mapper.Map<RefreshTokenDto>(result);
        }
    }
}
