using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Mediator;

namespace Modsen.CodeCorrida.Web.Application.UseCases.Queries.MyTestEntities;

public sealed record GetMyTestEntityQuery(int Id) : IQuery<MyTestEntityResponseDto>;