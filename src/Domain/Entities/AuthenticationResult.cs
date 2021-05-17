namespace CNode.Domain.Entities
{
    // TODO: move to the application layer
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
