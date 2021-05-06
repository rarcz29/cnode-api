using System.Collections.Generic;

namespace CNode.Application.Common.Dtos
{
    public class PlatformAccountDto
    {
        public string Name { get; set; }
        public IEnumerable<RepositoryDto> Repos { get; set; }
    }
}
