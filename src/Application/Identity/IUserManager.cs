namespace CNode.Application.Identity
{
    public interface IUserManager
    {
        string Authenticate(string email, string password);
    }
}
