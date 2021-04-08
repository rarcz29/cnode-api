using System.Collections.Generic;

namespace CNode.Domain.Entities
{
    public class TechnologyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public ICollection<Technology> Technologies { get; set; }
    }
}
