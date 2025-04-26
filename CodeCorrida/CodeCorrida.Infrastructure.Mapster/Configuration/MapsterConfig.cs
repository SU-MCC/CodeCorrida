using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace CodeCorrida.Infrastructure.Mapster.Configuration;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}

