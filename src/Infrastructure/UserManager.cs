using CNode.Application.Common.Data.Database;
using CNode.Application.Common.Identity;
using CNode.Application.Identity;
using CNode.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CNode.Infrastructure
{
    internal class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwt;

        public UserManager(IUnitOfWork unitOfWork, IJwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        public async Task<string> AuthenticateAsync(string usernameOrEmail, string password)
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

            if (users != null && users.Count() == 1)
            {
                var user = users.First();

                if (user.Password == password)
                {
                    return _jwt.CreateJwt(user);
                }
            }

            // Throw exception
            return null;
        }

        public async Task RegisterAsync(string username, string email, string password, bool twoFactorEnabled = false)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                TwoFactorEnabled = twoFactorEnabled,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Users.Add(user);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }

        public async Task RemoveAsync(int userId)
        {
            _unitOfWork.Users.Remove(userId);
            await _unitOfWork.SaveChangesAsync();
            // TODO: return value or exception when failured
        }
    }
}
