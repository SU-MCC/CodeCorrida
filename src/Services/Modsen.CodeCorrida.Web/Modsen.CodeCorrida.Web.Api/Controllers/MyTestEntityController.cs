using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Query;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Request;
using Modsen.CodeCorrida.Web.Application.DTOs.MyTestEntity.Response;
using Modsen.CodeCorrida.Web.Application.UseCases.Commands.MyTestEntities;
using Modsen.CodeCorrida.Web.Application.UseCases.Queries.MyTestEntities;
using Modsen.CodeCorrida.Web.Api.Models.Responses.Common;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Modsen.CodeCorrida.Web.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MyTestEntityController : ControllerBase
{
    private readonly IMediator _mediator;

    public MyTestEntityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMyTestEntities([FromQuery] GetAllMyTestEntityRequestDto requestDto, CancellationToken cancellationToken)
    {
        var query = new GetAllMyTestEntityQuery(requestDto);
        var entities = await _mediator.Send(query, cancellationToken);

        var availableEntities = PagedListResponse<MyTestEntityResponseDto>.ToPagedListResponse(entities);
        
        return new OkObjectResult(availableEntities);
    }
    
    [HttpGet("{myTestEntityId:int}")]
    public async Task<IActionResult> GetMyTestEntity([FromRoute] int myTestEntityId, CancellationToken cancellationToken)
    {
        return new OkObjectResult(await _mediator.Send(new GetMyTestEntityQuery( myTestEntityId), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateMyTestEntity(CreateMyTestEntityRequestDto createDto,
        CancellationToken cancellationToken)
    {
        var createMyTestEntityCommand = new CreateMyTestEntityCommand(createDto);
        return new OkObjectResult(await _mediator.Send(createMyTestEntityCommand, cancellationToken));
    }
    
    [HttpDelete("{myTestEntityId:int}")]
    public async Task<IActionResult> DeleteMyTestEntity([FromRoute] int myTestEntityId, CancellationToken cancellationToken)
    {
        var deleteMyTestEntityCommand = new DeleteMyTestEntityCommand(myTestEntityId);
        await _mediator.Send(deleteMyTestEntityCommand, cancellationToken);
        
        return new OkResult();
    }
    
    [HttpPut("{myTestEntityId:int}")]
    public async Task<IActionResult> RewriteMyTestEntity([FromRoute] int myTestEntityId, 
                                                         [FromBody] UpdateMyTestEntityRequestDto updateDto, 
                                                         CancellationToken cancellationToken)
    {
        
        updateDto.Id = myTestEntityId;
        var command = new UpdateMyTestEntityCommand(updateDto);
        var response = await _mediator.Send(command, cancellationToken);
        
        return new OkObjectResult(response);
    }
}