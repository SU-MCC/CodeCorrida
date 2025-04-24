using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CodeCorrida.Infrastructure.DataAccess.Extensions;

public static class BaseQueryableExtensions
{
    public static IQueryable<TEntity> FilterByExpression<TEntity>(
        this IQueryable<TEntity> entities,
        Expression<Func<TEntity, bool>>? filterExpression)
        where TEntity : class
    {
        if (filterExpression == null)
        {
            return entities;
        }

        return entities.Where(filterExpression);
    }

    public static IQueryable<TEntity> TrackChanges<TEntity>(
        this IQueryable<TEntity> query,
        bool trackChanges)
        where TEntity : class
    {
        if (trackChanges)
        {
            return query;
        }

        return query.AsNoTracking();
    }

    public static IQueryable<TEntity> Paginate<TEntity>(
        this IQueryable<TEntity> query,
        int pageSize,
        int pageNumber
    )
    {
        if (pageSize <= 0)
        {
            return query;
        }

        return query
            .Skip(pageNumber * pageSize)
            .Take(pageSize);
    }
}
