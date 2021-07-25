using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string OriginId { get; set; }
        public string OriginUrl { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }

        public ICollection<Repository> Repositories { get; set; }
    }
}
