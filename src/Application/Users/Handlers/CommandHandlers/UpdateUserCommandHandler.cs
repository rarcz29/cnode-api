using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Interfaces;
using CNode.Application.Users.Commands.UpdateUser;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CNode.Application.Users.Handlers.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(_currentUser.UserId);
            var user = await _unitOfWork.Users.GetAsync(userId);
            user.Username = request.Username;
            user.Email = request.Email;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
