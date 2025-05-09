using Modsen.CodeCorrida.Web.Application.DTOs.Common;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Modsen.CodeCorrida.Web.Application.UseCases.Queries.MyTestEntities;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.GetAllModels;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;
using Mapster;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Modsen.CodeCorrida.Web.Application.UseCases.QueryHandlers.MyTestEntities;

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