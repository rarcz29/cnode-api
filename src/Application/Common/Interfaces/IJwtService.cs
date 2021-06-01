using CNode.Domain.Entities;

namespace CNode.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateJwt(User user);
    }
}
