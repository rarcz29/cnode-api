using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Repository> Repositories { get; set; }
    }
}
