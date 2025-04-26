using CodeCorrida.Application.UseCases.Commands.MyTestEntities;
using CodeCorrida.Application.UseCases.QueryHandlers.MyTestEntities;
using CodeCorrida.Contracts.DataAccess.Interfaces;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CodeCorrida.Application.UseCases.CommandHandlers.MyTestEntities;

public class DeleteMyTestEntityCommandHandler : ICommandHandler<DeleteMyTestEntityCommand>
{
    private readonly ILogger<GetAllMyTestEntityQueryHandler> _logger;
    private readonly IMyTestEntityRepository _repository;

    public DeleteMyTestEntityCommandHandler(ILogger<GetAllMyTestEntityQueryHandler> logger, IMyTestEntityRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async ValueTask<Unit> Handle(DeleteMyTestEntityCommand command, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(command.id, cancellationToken);

        return default;
    }
}