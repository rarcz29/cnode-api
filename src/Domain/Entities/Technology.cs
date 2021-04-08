using System.Collections.Generic;

namespace CNode.Domain.Entities
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TechnologyTypeId { get; set; }
        public TechnologyType TechnologyType { get; set; }

        public ICollection<Repository> Repositories { get; set; }
    }
}
