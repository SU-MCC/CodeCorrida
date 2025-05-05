using System.Reflection;
using System.Text.RegularExpressions;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Modsen.CodeCorrida.Web.Infrastructure.DataAccess.Contexts;

public sealed class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    { }

    public DbSet<MyTestEntity> MyTestEntities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        AddTimestamps();

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        AddTimestamps();

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AddTimestamps()
    {
        var entitiesToTrack = ChangeTracker.Entries<BaseEntity>()
            .Where(x => x.State is EntityState.Added or EntityState.Modified);

        var now = DateTimeOffset.UtcNow;

        foreach (var entityEntry in entitiesToTrack)
        {
            var entity = entityEntry.Entity;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = now;
            }

            entity.LastModifiedAt = now;
        }
    }
}
