using System;
using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
