using CodeCorrida.Domain.Entities;
using CodeCorrida.Infrastructure.DataAccess.Contexts;
using CodeCorrida.Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace CodeCorrida.Infrastructure.DataAccess.Helpers;

public sealed class BaseDbContextSeed : IBaseDbContextSeed
{
    private readonly IDbContextFactory<BaseDbContext> _dbContextFactory;
    private readonly ILogger<BaseDbContextSeed> _logger;

    public BaseDbContextSeed(IDbContextFactory<BaseDbContext> contextFactory,
        ILogger<BaseDbContextSeed> logger)
    {
        _dbContextFactory = contextFactory;
        _logger = logger;
    }

    public void Migrate()
    {
        using var context = _dbContextFactory.CreateDbContext();
        //context.Database.EnsureDeleted();
        context.Database.Migrate();
    }

    public void EnsureCreated()
    {
        using var context = _dbContextFactory.CreateDbContext();

        context.Database.EnsureCreated();
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var policy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(
                retryCount: 5,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    //logs
                }
            );

        await policy.ExecuteAsync(async () =>
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            
            if (!context.MyTestEntities.Any())
            {
                var entities = new List<MyTestEntity>()
                {
                    new MyTestEntity() { Name = "Test obj 1", PropertyA = 1, PropertyB = 5},
                    new MyTestEntity() { Name = "Test obj 2", PropertyA = 10, PropertyB = 15},
                    new MyTestEntity() { Name = "Test obj 3", PropertyA = 2, PropertyB = 2},
                    new MyTestEntity() { Name = "Test obj 4", PropertyA = 7, PropertyB = 9},
                    new MyTestEntity() { Name = "Test obj 5", PropertyA = 4, PropertyB = 12},
                };
                await context.MyTestEntities
                    .AddRangeAsync(entities, cancellationToken);
            }
            
            
            await context.SaveChangesAsync(cancellationToken);
        });
    }
}
