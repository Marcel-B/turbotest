using System.ComponentModel.DataAnnotations;
using com.marcelbenders.Aqua.Api.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.marcelbenders.Aqua.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessungController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessungController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ActionName("GetAll"), Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<MessungDto>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<MessungDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetMessungenQuery(HttpContext.GetUserIdentifier()), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [ActionName("updateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(MessungDto), StatusCodes.Status201Created)]
    public async Task<MessungDto> UpdateOneAsync(
        [FromRoute, Required] Guid id,
        [FromBody, Required] UpdateMessungCommand command,
        CancellationToken cancellationToken)
    {
        command.UserId = HttpContext.GetUserIdentifier();
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPost]
    [ActionName("CreateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(MessungDto), StatusCodes.Status201Created)]
    public async Task<MessungDto> CreateOneAsync([FromBody, Required] CreateMessungCommand command,
        CancellationToken cancellationToken)
    {
        command.UserId = HttpContext.GetUserIdentifier();
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    [ActionName("DeleteOneAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOneAsync(
        [FromRoute, Required] Guid id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteMessungCommand {Id = id}, cancellationToken);
        return Ok(id);
    }

    [HttpGet("{aquariumId:guid}/Messungen")]
    [ActionName("GetMessungenByAquariumIdAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMessungenByAquariumIdAsync(
        [FromRoute, Required] Guid aquariumId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMessungenByAquariumIdQuery(aquariumId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{aquariumId:guid}/Messwerte")]
    [ActionName("GetMesswerteByAquariumIdAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AquariumMesswerteDto>> GetMesswerteByAquariumIdAsync(
        [FromRoute, Required] Guid aquariumId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMesswerteByAquariumIdQuery(aquariumId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{aquariumId:guid}/Messungen/{wert}")]
    [ActionName("GetMessungenByAquariumIdByMesswertAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AquariumMesswerteDto>> GetMessungenByAquariumIdByMesswertAsync(
        [FromRoute, Required] Guid aquariumId,
        [FromRoute, Required] string wert,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMessungenByAquariumIdByMesswertQuery(aquariumId, wert), cancellationToken);
        return Ok(result);
    }
}