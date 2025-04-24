namespace CodeCorrida.Contracts.Mapper.Interfaces;

public interface IMapper
{
    TDestination AdaptTo<TDestination>(object source);
    IQueryable<TDestination> ProjectTo<TDestination, TSource>(IQueryable<TSource> source);
}
