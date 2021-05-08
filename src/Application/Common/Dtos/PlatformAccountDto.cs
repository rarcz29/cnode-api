using CNode.Application.Common.Mappings;
using CNode.Application.Common.Models;
using System.Collections.Generic;

namespace CNode.Application.Common.Dtos
{
    public class PlatformAccountDto : PlatformNewAccountDto, IMapFrom<PlatformUser>
    {
        public IEnumerable<PlatformRepositoryDto> Repos { get; set; }
    }
}
