using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using CodeCorrida.Application.UseCases.Commands.MyTestEntities;
using CodeCorrida.Application.UseCases.QueryHandlers.MyTestEntities;
using CodeCorrida.Contracts.DataAccess.Interfaces;
using CodeCorrida.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CodeCorrida.Application.UseCases.CommandHandlers.MyTestEntities;

public class CreateMyTestEntityCommandHandler : ICommandHandler<CreateMyTestEntityCommand, CreateMyTestEntityResponseDto>
{
    private readonly ILogger<GetAllMyTestEntityQueryHandler> _logger;
    private readonly IMyTestEntityRepository _repository;


    public CreateMyTestEntityCommandHandler(ILogger<GetAllMyTestEntityQueryHandler> logger, 
                                            IMyTestEntityRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<CreateMyTestEntityResponseDto> Handle(CreateMyTestEntityCommand command, CancellationToken cancellationToken)
    {
        var myTestEntity = command.createDto.Adapt<MyTestEntity>();
        myTestEntity = await _repository.AddAsync(myTestEntity, cancellationToken);
        
        var response = myTestEntity.Adapt<CreateMyTestEntityResponseDto>();
        
        return response;
    }
}