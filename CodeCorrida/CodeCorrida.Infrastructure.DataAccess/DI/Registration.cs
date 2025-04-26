using CodeCorrida.Contracts.DataAccess.Interfaces;
using CodeCorrida.Infrastructure.DataAccess.Contexts;
using CodeCorrida.Infrastructure.DataAccess.Helpers;
using CodeCorrida.Infrastructure.DataAccess.Interfaces;
using CodeCorrida.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeCorrida.Infrastructure.DataAccess.DI;

public static class Registration
{
    public static IServiceCollection AddDataAccessDependencies(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        AddDatabase(serviceCollection, configuration, environment);
        
        serviceCollection.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromHours(2));

        serviceCollection.AddScoped<IBaseDbContextSeed, BaseDbContextSeed>()
            .AddScoped<IMyTestEntityRepository, MyTestEntityRepository>();
        
        return serviceCollection;
    }

    private static void AddDatabase(
        IServiceCollection serviceCollection,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        var dbConnectionString = configuration!.GetSection("DbConnection").Value;

        if (string.IsNullOrEmpty(dbConnectionString))
        {
            dbConnectionString = configuration!.GetConnectionString("BaseDbConnection");
        }

        serviceCollection.AddDbContextFactory<BaseDbContext>(options => options.UseNpgsql(dbConnectionString),
            ServiceLifetime.Transient);
    }
}
