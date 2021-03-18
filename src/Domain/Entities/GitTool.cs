using System.Collections.Generic;

namespace CNode.Domain.Entities
{
    public class GitTool
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GitAccount> GitUsers { get; set; }
    }
}
