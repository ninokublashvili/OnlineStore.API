using AutoMapper;

namespace OnlineStore.Application.Shared.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
