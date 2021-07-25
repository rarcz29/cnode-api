using System.Collections.Generic;

namespace GitNode.Domain.Entities
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public bool Share { get; set; }
        public string OriginId { get; set; }
        public string OriginName { get; set; }
        public string OriginUrl { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<Technology> Technologies { get; set; }
    }
}
