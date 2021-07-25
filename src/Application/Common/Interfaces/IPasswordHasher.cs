namespace GitNode.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string CreateHash(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}
