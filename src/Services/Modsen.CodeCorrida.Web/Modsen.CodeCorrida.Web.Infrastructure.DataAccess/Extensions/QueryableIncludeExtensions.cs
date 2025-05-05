using System.Linq.Expressions;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Extensions;

public static class QueryableIncludeExtensions
{
    private static readonly Type[] OneTypeArray = new Type[1];
    private static readonly Expression[] TwoExpressionArray = new Expression[2];

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> Include<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        Expression<Func<TEntity, IEnumerable<TProperty>>> navigationPropertyPath,
        Expression<Func<TProperty, bool>> filterBy,
        bool when)
        where TEntity : class
    {
        if (when)
        {
            navigationPropertyPath = GetPathWithFilter(navigationPropertyPath, filterBy);
        }

        return source.Include(navigationPropertyPath);
    }

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> ThenInclude<TEntity, TPreviousProperty,
        TProperty>(
        this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, IEnumerable<TProperty>>> navigationPropertyPath,
        Expression<Func<TProperty, bool>> filterBy,
        bool when)
        where TEntity : class
    {
        if (when)
        {
            navigationPropertyPath = GetPathWithFilter(navigationPropertyPath, filterBy);
        }

        return source.ThenInclude(navigationPropertyPath);
    }

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> ThenInclude<TEntity, TPreviousProperty,
        TProperty>(
        this IIncludableQueryable<TEntity, TPreviousProperty> source,
        Expression<Func<TPreviousProperty, IEnumerable<TProperty>>> navigationPropertyPath,
        Expression<Func<TProperty, bool>> filterBy,
        bool when)
        where TEntity : class
    {
        if (when)
        {
            navigationPropertyPath = GetPathWithFilter(navigationPropertyPath, filterBy);
        }

        return source.ThenInclude(navigationPropertyPath);
    }

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> Include<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        Expression<Func<TEntity, IEnumerable<TProperty>>> navigationPropertyPath,
        bool includeDeleted)
        where TEntity : class
        where TProperty : ISoftDeletable
    {
        return source.Include(
            navigationPropertyPath, 
            filterBy: deletable => !deletable.IsDeleted,
            when: !includeDeleted);
    }

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> ThenInclude<TEntity, TPreviousProperty,
        TProperty>(
        this IIncludableQueryable<TEntity, TPreviousProperty> source,
        Expression<Func<TPreviousProperty, IEnumerable<TProperty>>> navigationPropertyPath,
        bool includeDeleted)
        where TEntity : class
        where TProperty : ISoftDeletable
    {
        return source.ThenInclude(
            navigationPropertyPath,
            filterBy: deletable => !deletable.IsDeleted,
            when: !includeDeleted);
    }

    public static IIncludableQueryable<TEntity, IEnumerable<TProperty>> ThenInclude<TEntity, TPreviousProperty,
        TProperty>(
        this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
        Expression<Func<TPreviousProperty, IEnumerable<TProperty>>> navigationPropertyPath,
        bool includeDeleted)
        where TEntity : class
        where TProperty : ISoftDeletable
    {
        return source.ThenInclude(
            navigationPropertyPath,
            filterBy: deletable => !deletable.IsDeleted,
            when: !includeDeleted);
    }

    private static Expression<Func<TEntity, IEnumerable<TProperty>>> GetPathWithFilter<TEntity, TProperty>(
        Expression<Func<TEntity, IEnumerable<TProperty>>> path,
        Expression<Func<TProperty, bool>> condition)
    {
        OneTypeArray[0] = typeof(TProperty);

        TwoExpressionArray[0] = Expression.Convert(path.Body, typeof(IEnumerable<TProperty>));
        TwoExpressionArray[1] = condition;

        var whereCall = Expression.Call(typeof(Enumerable), "Where", OneTypeArray, TwoExpressionArray);

        return Expression.Lambda<Func<TEntity, IEnumerable<TProperty>>>(whereCall, path.Parameters);
    }
}
