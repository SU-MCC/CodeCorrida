using Mediator;

namespace CodeCorrida.Application.UseCases.Commands.MyTestEntities;

public sealed record DeleteMyTestEntityCommand(int id) : ICommand;