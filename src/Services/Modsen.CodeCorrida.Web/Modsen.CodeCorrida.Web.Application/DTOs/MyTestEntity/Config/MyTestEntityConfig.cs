using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Request;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Mapster;

namespace Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Config;

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
        
        TypeAdapterConfig<Domain.Entities.MyTestEntity, CreateMyTestEntityResponseDto>
            .NewConfig()
            .Map(destination => destination.Id, source => source.Id)
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PropertyA, source => source.PropertyA)
            .Map(destination => destination.PropertyB, source => source.PropertyB);
        
        TypeAdapterConfig<CreateMyTestEntityRequestDto, Domain.Entities.MyTestEntity>
            .NewConfig()
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PropertyA, source => source.PropertyA)
            .Map(destination => destination.PropertyB, source => source.PropertyB);
        
        TypeAdapterConfig<UpdateMyTestEntityResponseDto, Domain.Entities.MyTestEntity>
            .NewConfig()
            .Map(destination => destination.Id, source => source.Id)
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PropertyA, source => source.PropertyA)
            .Map(destination => destination.PropertyB, source => source.PropertyB);
        
        TypeAdapterConfig<Domain.Entities.MyTestEntity, UpdateMyTestEntityRequestDto>
            .NewConfig()
            .Map(destination => destination.Id, source => source.Id)
            .Map(destination => destination.Name, source => source.Name)
            .Map(destination => destination.PropertyA, source => source.PropertyA)
            .Map(destination => destination.PropertyB, source => source.PropertyB);
    }
}