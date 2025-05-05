using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Config;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure;

public static class MapsterConfig
{
    public static void RegisterMappingConfig()
    {
        MyTestEntityConfig.Register();
    }
}
