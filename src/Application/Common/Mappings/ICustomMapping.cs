using AutoMapper.Configuration;

namespace CNode.Application.Common.Mappings
{
    public interface ICustomMapping
    {
        void CreateMappings(IConfiguration configuration);
    }
}
