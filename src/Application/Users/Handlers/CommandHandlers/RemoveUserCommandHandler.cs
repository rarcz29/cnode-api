using System.Threading;
using System.Threading.Tasks;
using GitNode.Application.Common.Data.Database;
using GitNode.Application.Common.Interfaces;
using GitNode.Application.Users.Commands.RemoveUser;
using GitNode.Domain.Entities;
using MediatR;

namespace GitNode.Application.Users.Handlers.CommandHandlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public RemoveUserCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(_currentUser.UserId);
            _unitOfWork.Users.Remove(new User { Id = userId });
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
