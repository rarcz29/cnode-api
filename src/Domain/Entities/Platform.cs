using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
