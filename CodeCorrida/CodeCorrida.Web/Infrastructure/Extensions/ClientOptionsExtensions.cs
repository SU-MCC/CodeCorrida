using CodeCorrida.Domain.Options;

namespace CodeCorrida.Web.Infrastructure.Extensions;

public static class ClientOptionsExtensions
{
    public static IServiceCollection AddClientOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ClientOptions>(configuration.GetSection(ClientOptions.ConfigName));

        return services;
    }
}
