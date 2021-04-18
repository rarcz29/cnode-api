using CNode.Domain.Entities;

namespace CNode.Application.Common.Identity
{
    public interface IJwtService
    {
        string CreateJwt(User user);
    }
}
