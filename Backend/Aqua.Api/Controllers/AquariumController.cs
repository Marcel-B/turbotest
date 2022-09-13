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
public class AquariumController : ControllerBase
{
    private readonly IMediator _mediator;

    public AquariumController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ActionName("GetAll"), Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<AquariumDto>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<AquariumDto>> GetAll(
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAquarienQuery(HttpContext.GetUserIdentifier()), cancellationToken);
    }

    [HttpPost]
    [ActionName("CreateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(AquariumDto), StatusCodes.Status201Created)]
    public async Task<AquariumDto> CreateOneAsync(
        [FromBody, Required] CreateAquariumCommand command,
        CancellationToken cancellationToken)
    {
        var userId = HttpContext.GetUserIdentifier();
        command.UserId = userId;
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [ActionName("updateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(AquariumDto), StatusCodes.Status201Created)]
    public async Task<AquariumDto> UpdateOneAsync(
        [FromRoute, Required] Guid id,
        [FromBody, Required] UpdateAquariumCommand command,
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
        await _mediator.Send(new DeleteAquariumCommand {Id = id}, cancellationToken);
        return Ok(id);
    }
}