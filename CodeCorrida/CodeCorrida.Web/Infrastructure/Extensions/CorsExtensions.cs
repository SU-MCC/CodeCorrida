using CodeCorrida.Domain.Options;

namespace CodeCorrida.Web.Infrastructure.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddClientCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options => options.AddDefaultPolicy(builder =>
        {
            builder
                .WithOrigins(configuration.GetSection(ClientHostsOptions.ConfigName).GetChildren().Select(hostSection => hostSection.Value ?? "").ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithExposedHeaders(HeadersKeysConstants.PaginationKey);
        }));

        return services;
    }
}
