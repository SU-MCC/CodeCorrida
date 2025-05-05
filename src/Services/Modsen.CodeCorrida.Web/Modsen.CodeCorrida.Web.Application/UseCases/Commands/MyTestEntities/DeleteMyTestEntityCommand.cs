using Mediator;

namespace Modsen.CodeCorrida.Web.Application.UseCases.Commands.MyTestEntities;

public sealed record DeleteMyTestEntityCommand(int id) : ICommand;