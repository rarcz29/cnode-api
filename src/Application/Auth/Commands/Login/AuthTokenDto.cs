namespace CNode.Application.Auth.Commands.Login
{
    public class AuthTokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Type { get; set; }
    }
}
