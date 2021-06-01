using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Interfaces;
using CNode.Application.Users.Commands.RemoveUser;
using CNode.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Users.Handlers.CommandHandlers
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
