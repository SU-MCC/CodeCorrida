using CodeCorrida.Contracts.Mapper.Interfaces;

namespace CodeCorrida.Infrastructure.DataAccess.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TDestination> ProjectTo<TDestination, TSource>(this IQueryable<TSource> queryable, IMapper mapper)
    {
        return mapper.ProjectTo<TDestination, TSource>(queryable);
    }
}
