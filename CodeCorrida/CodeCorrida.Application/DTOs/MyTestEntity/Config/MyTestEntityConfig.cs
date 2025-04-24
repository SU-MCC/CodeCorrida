using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using Mapster;

namespace CodeCorrida.Application.DTOs.MyTestEntity.Config;

public static class MyTestEntityConfig
{
    public static void Register()
    {
        TypeAdapterConfig<Domain.Entities.MyTestEntity, MyTestEntityResponseDto>
            .NewConfig()
            .Map(destination => destination.Id, source => source.Id)
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PropertyA, source => source.PropertyA)
            .Map(destination => destination.PropertyB, source => source.PropertyB);
    }
}