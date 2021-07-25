using GitNode.Domain.Entities;

namespace GitNode.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateJwt(User user);
    }
}
