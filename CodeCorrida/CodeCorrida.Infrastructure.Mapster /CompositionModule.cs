using System.Reflection;
using CodeCorrida.Contracts.Mapper.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCorrida.Infrastructure.Mapster;

public static class CompositionModule
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        services.AddScoped<IMapper, MapsterMapper>();
    }
}
