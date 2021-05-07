using AutoMapper;

namespace CNode.Application.Common.Mappings
{
    interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
