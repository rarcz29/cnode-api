using System.Collections.Generic;
using GitNode.Application.Common.Mappings;
using GitNode.Domain.Platforms;

namespace GitNode.Application.Common.Dtos
{
    public class PlatformAccountDto : PlatformNewAccountDto, IMapFrom<PlatformUser>
    {
        public IEnumerable<PlatformRepositoryDto> Repos { get; set; }
    }
}
