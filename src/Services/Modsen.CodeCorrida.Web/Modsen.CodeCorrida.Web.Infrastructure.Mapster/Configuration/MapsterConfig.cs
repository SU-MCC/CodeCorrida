using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Modsen.CodeCorrida.Web.Infrastructure.Mapster.Configuration;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}

