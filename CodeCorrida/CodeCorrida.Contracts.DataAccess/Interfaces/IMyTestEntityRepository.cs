using CodeCorrida.Contracts.DataAccess.GetAllModels;
using CodeCorrida.Domain.Entities;
using CodeCorrida.Domain.RequestFeatures;

namespace CodeCorrida.Contracts.DataAccess.Interfaces;

public interface IMyTestEntityRepository : IBaseRepository<MyTestEntity>
{
    Task<PagedList<TDestination>> GetAllWithPaginationAsync<TDestination>(GetAllMyTestEntitiesModel model, 
                                                            CancellationToken cancellationToken);
}