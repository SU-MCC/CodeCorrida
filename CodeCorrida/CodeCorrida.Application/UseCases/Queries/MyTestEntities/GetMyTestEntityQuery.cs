using CodeCorrida.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace CodeCorrida.Application.UseCases.Queries.MyTestEntities;

public sealed record GetMyTestEntityQuery(int Id) : IQuery<MyTestEntityResponseDto>;