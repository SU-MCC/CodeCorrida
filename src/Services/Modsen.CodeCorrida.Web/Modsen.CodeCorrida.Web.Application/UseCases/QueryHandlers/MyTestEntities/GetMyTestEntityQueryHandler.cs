using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Modsen.CodeCorrida.Web.Application.UseCases.Queries.MyTestEntities;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;
using Modsen.CodeCorrida.Web.Domain.Exceptions.NotFound;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Modsen.CodeCorrida.Web.Application.UseCases.QueryHandlers.MyTestEntities;

public class GetMyTestEntityQueryHandler: IQueryHandler<GetMyTestEntityQuery, MyTestEntityResponseDto>
{
    private readonly ILogger<GetAllMyTestEntityQueryHandler> _logger;
    private readonly IMyTestEntityRepository _repository;


    public GetMyTestEntityQueryHandler(ILogger<GetAllMyTestEntityQueryHandler> logger, IMyTestEntityRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<MyTestEntityResponseDto> Handle(GetMyTestEntityQuery query, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAsync<MyTestEntityResponseDto>(e => e.Id == query.Id, cancellationToken);

        if (response == null)
        {
            throw new NotFoundException($"My Test Entity with Id = {query.Id} not found");
        }
        
        return response;
    }
}