using CodeCorrida.Contracts.DataAccess.GetAllModels;
using CodeCorrida.Contracts.DataAccess.Interfaces;
using CodeCorrida.Contracts.Mapper.Interfaces;
using CodeCorrida.Domain.Entities;
using CodeCorrida.Domain.RequestFeatures;
using CodeCorrida.Infrastructure.DataAccess.Contexts;
using CodeCorrida.Infrastructure.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodeCorrida.Infrastructure.DataAccess.Repositories;

public class MyTestEntityRepository : BaseRepository<MyTestEntity>, IMyTestEntityRepository
{
    public MyTestEntityRepository(BaseDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    { }

    public async Task<PagedList<TDestination>> GetAllWithPaginationAsync<TDestination>(GetAllMyTestEntitiesModel model, 
                                                                         CancellationToken cancellationToken)
    {
        var query = _dbContext.MyTestEntities
            .OrderByDescending(test => test.CreatedAt);

        var count = await query.CountAsync(cancellationToken);

        var projectedQuery = typeof(TDestination) == typeof(MyTestEntity)
            ? query as IQueryable<TDestination>
            : query.ProjectTo<TDestination, MyTestEntity>(_mapper);
        
        var entities = await projectedQuery!
            .Skip(model.PageSize * (model.PageNumber - 1))
            .Take(model.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedList<TDestination>(
            entities,
            count,
            model.PageNumber,
            model.PageSize);
    }
}