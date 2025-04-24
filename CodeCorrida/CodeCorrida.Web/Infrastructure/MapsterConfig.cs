using CodeCorrida.Application.DTOs.MyTestEntity.Config;

namespace CodeCorrida.Web.Infrastructure;

public static class MapsterConfig
{
    public static void RegisterMappingConfig()
    {
        MyTestEntityConfig.Register();
    }
}
