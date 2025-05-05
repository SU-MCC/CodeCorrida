using Modsen.CodeCorrida.Web.Application.DTOs.Common;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Query;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace Modsen.CodeCorrida.Web.Application.UseCases.Queries.MyTestEntities;

public sealed record GetAllMyTestEntityQuery(GetAllMyTestEntityRequestDto RequestDto) 
    : IQuery<PagedListDto<MyTestEntityResponseDto>>;