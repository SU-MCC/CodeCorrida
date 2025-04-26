using CodeCorrida.Application.DTOs.Common;
using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using CodeCorrida.Application.UseCases.Queries.MyTestEntities;
using CodeCorrida.Contracts.DataAccess.GetAllModels;
using CodeCorrida.Contracts.DataAccess.Interfaces;
using Mapster;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CodeCorrida.Application.UseCases.QueryHandlers.MyTestEntities;

public class GetAllMyTestEntityQueryHandler : IQueryHandler<GetAllMyTestEntityQuery, PagedListDto<MyTestEntityResponseDto>>
{
    private readonly ILogger<GetAllMyTestEntityQueryHandler> _logger;
    private readonly IMyTestEntityRepository _repository;

    public GetAllMyTestEntityQueryHandler(ILogger<GetAllMyTestEntityQueryHandler> logger, IMyTestEntityRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<PagedListDto<MyTestEntityResponseDto>> Handle(GetAllMyTestEntityQuery query, CancellationToken cancellationToken)
    {
        var getAllModel = new GetAllMyTestEntitiesModel(query.RequestDto.PageNumber, query.RequestDto.PageSize);
        var entities = await _repository.GetAllWithPaginationAsync<MyTestEntityResponseDto>(getAllModel, cancellationToken);
        
        return PagedListDto<MyTestEntityResponseDto>.ToPagedListDto(entities);
    }
}