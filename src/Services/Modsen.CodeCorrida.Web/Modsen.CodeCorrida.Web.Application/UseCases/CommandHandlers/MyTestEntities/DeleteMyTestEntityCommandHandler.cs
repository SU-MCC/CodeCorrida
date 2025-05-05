using Modsen.CodeCorrida.Web.Application.UseCases.Commands.MyTestEntities;
using Modsen.CodeCorrida.Web.Application.UseCases.QueryHandlers.MyTestEntities;
using Modsen.CodeCorrida.Web.Contracts.DataAccess.Interfaces;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Modsen.CodeCorrida.Web.Application.UseCases.CommandHandlers.MyTestEntities;

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