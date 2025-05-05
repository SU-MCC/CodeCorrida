using Modsen.CodeCorrida.Web.Contracts.DataAccess.GetAllModels;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Modsen.CodeCorrida.Web.Domain.RequestFeatures;

namespace Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;

public interface IMyTestEntityRepository : IBaseRepository<MyTestEntity>
{
    Task<PagedList<TDestination>> GetAllWithPaginationAsync<TDestination>(GetAllMyTestEntitiesModel model, 
                                                            CancellationToken cancellationToken);
}