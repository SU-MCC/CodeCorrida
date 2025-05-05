using System.Reflection;
using Modsen.CodeCorrida.Web.Contracts.Mapper.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Modsen.CodeCorrida.Web.Infrastructure.Mapster;

public static class CompositionModule
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        services.AddScoped<IMapper, MapsterMapper>();
    }
}
