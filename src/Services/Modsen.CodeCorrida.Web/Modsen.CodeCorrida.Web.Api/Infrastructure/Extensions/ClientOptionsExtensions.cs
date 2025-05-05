using Modsen.CodeCorrida.Web.Domain.Options;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class ClientOptionsExtensions
{
    public static IServiceCollection AddClientOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ClientOptions>(configuration.GetSection(ClientOptions.ConfigName));

        return services;
    }
}
