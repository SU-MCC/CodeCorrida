using Polly;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class WebHostExtensions
{
    public static void MigrateDbContext(Action migrate, Action seed, ILogger logger)
    {
        try
        {
            logger.LogInformation("Migrating database associated with context");
            var retries = 10;

            var retry = Policy.Handle<Exception>()
                .WaitAndRetry(
                    retryCount: retries,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        //logs
                    });

            //if the sql server container is not created on run docker compose this
            //migration can't fail for network related exception. The retry options for DbContext only 
            //apply to transient exceptions
            // Note that this is NOT applied when running some orchestrators (let the orchestrator to recreate the failing service)
            retry.Execute(() => InvokeSeeder(migrate, seed));
            logger.LogInformation("Migrated database associated with context");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context");
        }
    }

    private static void InvokeSeeder(Action migrate, Action seed)
    {
        migrate();
        seed();
    }
}
