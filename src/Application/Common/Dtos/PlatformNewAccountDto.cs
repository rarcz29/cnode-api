using CNode.Application.Common.Mappings;
using CNode.Application.Common.Models;

namespace CNode.Application.Common.Dtos
{
    public class PlatformNewAccountDto : IMapFrom<PlatformUser>
    {
        public string Login { get; set; }
    }
}
