using CodeCorrida.Application.DTOs.Common;
using CodeCorrida.Application.DTOs.MyTestEntity.Query;
using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace CodeCorrida.Application.UseCases.Queries.MyTestEntities;

public sealed record GetAllMyTestEntityQuery(GetAllMyTestEntityRequestDto RequestDto) 
    : IQuery<PagedListDto<MyTestEntityResponseDto>>;