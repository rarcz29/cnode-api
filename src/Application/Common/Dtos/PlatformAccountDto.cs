using System.Collections.Generic;
using GitNode.Application.Common.Mappings;
using GitNode.Application.Common.Models;

namespace GitNode.Application.Common.Dtos
{
    public class PlatformAccountDto : PlatformNewAccountDto, IMapFrom<PlatformUser>
    {
        public IEnumerable<PlatformRepositoryDto> Repos { get; set; }
    }
}
