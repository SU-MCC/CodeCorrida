using CodeCorrida.Infrastructure.DataAccess.Interfaces;

namespace CodeCorrida.Web.Infrastructure.Extensions;

public static class ServiceProviderExtensions
{
    public static IServiceProvider MigrateAndSeedDatabase(this IServiceProvider services)
    {
        var environment = services.GetRequiredService<IWebHostEnvironment>();
        var logger = services.GetRequiredService<ILogger<IWebHost>>();
        var baseDbContextSeed = services.GetRequiredService<IBaseDbContextSeed>();

        var migrate = () => baseDbContextSeed.Migrate();
        var seed = () => baseDbContextSeed.SeedAsync().Wait();

        /*
        if (environment.IsTest())
        {
            migrate = () => baseDbContextSeed.EnsureCreated();
        }
        */
        
        WebHostExtensions.MigrateDbContext(migrate, seed, logger);

        if (!environment.IsProduction())
        { }

        return services;
    }
}
