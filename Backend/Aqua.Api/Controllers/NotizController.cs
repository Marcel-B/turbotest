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
public class NotizController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotizController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ActionName("GetAll"), Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<NotizDto>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<NotizDto>> GetAll(
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetNotizenQuery(HttpContext.GetUserIdentifier()), cancellationToken);
    }

    [HttpPost]
    [ActionName("CreateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(NotizDto), StatusCodes.Status201Created)]
    public async Task<NotizDto> CreateOneAsync(
        [FromBody, Required] CreateNotizCommand command,
        CancellationToken cancellationToken)
    {
        command.UserId = HttpContext.GetUserIdentifier();
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    [ActionName("updateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(NotizDto), StatusCodes.Status201Created)]
    public async Task<NotizDto> UpdateOneAsync(
        [FromRoute, Required] string id,
        [FromBody, Required] UpdateNotizCommand command,
        CancellationToken cancellationToken)
    {
        command.UserId = HttpContext.GetUserIdentifier() ?? throw new ArgumentNullException("UserId nicht gefunden");
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteOneAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOneAsync(
        [FromRoute, Required] Guid id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteNotizCommand {Id = id}, cancellationToken);
        return Ok(id);
    }
}