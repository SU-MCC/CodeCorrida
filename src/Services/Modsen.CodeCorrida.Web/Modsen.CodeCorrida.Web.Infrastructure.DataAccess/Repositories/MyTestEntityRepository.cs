using Modsen.CodeCorrida.Web.Contracts.DataAccess.GetAllModels;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;
using Modsen.CodeCorrida.Web.Contracts.Mapper.Interfaces;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Modsen.CodeCorrida.Web.Domain.RequestFeatures;
using Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Contexts;
using Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Repositories;

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