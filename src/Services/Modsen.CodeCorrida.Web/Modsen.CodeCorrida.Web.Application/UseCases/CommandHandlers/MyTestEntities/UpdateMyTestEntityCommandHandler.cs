using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Modsen.CodeCorrida.Web.Application.UseCases.Commands.MyTestEntities;
using Modsen.CodeCorrida.Web.Application.UseCases.QueryHandlers.MyTestEntities;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;
using Modsen.CodeCorrida.Web.Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Modsen.CodeCorrida.Web.Application.UseCases.CommandHandlers.MyTestEntities;

public class UpdateMyTestEntityCommandHandler : ICommandHandler<UpdateMyTestEntityCommand, UpdateMyTestEntityResponseDto>
{
    private readonly ILogger<GetAllMyTestEntityQueryHandler> _logger;
    private readonly IMyTestEntityRepository _repository;


    public UpdateMyTestEntityCommandHandler(ILogger<GetAllMyTestEntityQueryHandler> logger, IMyTestEntityRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<UpdateMyTestEntityResponseDto> Handle(UpdateMyTestEntityCommand command, CancellationToken cancellationToken)
    {
        var response = (await isExists(command.updateDto.Id)) ?
            await _repository.UpdateAsync(command.updateDto.Adapt<MyTestEntity>(), cancellationToken) :
            await _repository.AddAsync(command.updateDto.Adapt<MyTestEntity>(), cancellationToken);

        return response.Adapt<UpdateMyTestEntityResponseDto>();
    }

    private async Task<bool> isExists(int id)
    {
        var count = await _repository.CountByConditionAsync(e => e.Id == id);
        
        return count > 0;
    }
}