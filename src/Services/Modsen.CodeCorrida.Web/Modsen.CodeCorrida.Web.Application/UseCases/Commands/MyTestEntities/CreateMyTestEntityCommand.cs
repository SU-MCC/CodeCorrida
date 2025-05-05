using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Request;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace Modsen.CodeCorrida.Web.Application.UseCases.Commands.MyTestEntities;

public sealed record CreateMyTestEntityCommand(CreateMyTestEntityRequestDto createDto) 
    : ICommand<CreateMyTestEntityResponseDto>;