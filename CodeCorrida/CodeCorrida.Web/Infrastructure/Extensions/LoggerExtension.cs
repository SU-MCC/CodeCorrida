using Serilog;

namespace CodeCorrida.Web.Infrastructure.Extensions;

public static class LoggerExtension
{
    public static void ConfigureLogger(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Async(writeTo => writeTo.Console())
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog(logger);
    }
}
