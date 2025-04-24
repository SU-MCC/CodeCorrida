using CodeCorrida.Application.DTOs.MyTestEntity.Request;
using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace CodeCorrida.Application.UseCases.Commands.MyTestEntities;

public sealed record UpdateMyTestEntityCommand(UpdateMyTestEntityRequestDto createDto) 
    : ICommand<UpdateMyTestEntityResponseDto>;