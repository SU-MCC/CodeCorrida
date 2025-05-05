using Modsen.CodeCorrida.Web.Contracts.Mapper.Interfaces;
using Mapster;

namespace Modsen.CodeCorrida.Web.Infrastructure.Mapster;

public sealed class MapsterMapper : IMapper
{
    public TDestination AdaptTo<TDestination>(object source)
    {
        return source.Adapt<TDestination>();
    }

    public IQueryable<TDestination> ProjectTo<TDestination, TSource>(IQueryable<TSource> source)
    {
        return source.ProjectToType<TDestination>();
    }
}
