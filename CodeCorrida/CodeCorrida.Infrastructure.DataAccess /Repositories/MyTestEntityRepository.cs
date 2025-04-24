using CodeCorrida.Contracts.DataAccess.Interfaces;
using CodeCorrida.Contracts.Mapper.Interfaces;
using CodeCorrida.Domain.Entities;
using CodeCorrida.Infrastructure.DataAccess.Contexts;

namespace CodeCorrida.Infrastructure.DataAccess.Repositories;

public class MyTestEntityRepository : BaseRepository<MyTestEntity>, IMyTestEntityRepository
{
    public MyTestEntityRepository(BaseDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    { }
}