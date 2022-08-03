using System.ComponentModel.DataAnnotations;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.marcelbenders.Aqua.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PflanzeController : ControllerBase
{
    private readonly IMediator _mediator;

    public PflanzeController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ActionName("GetAll"), Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<PflanzeDto>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<PflanzeDto>> GetAll(
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetPflanzenQuery(), cancellationToken);
    }

    [HttpPost]
    [ActionName("CreateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(PflanzeDto), StatusCodes.Status201Created)]
    public async Task<PflanzeDto> CreateOneAsync(
        [FromBody, Required] CreatePflanzeCommand command,
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    [ActionName("updateOneAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(PflanzeDto), StatusCodes.Status201Created)]
    public async Task<PflanzeDto> UpdateOneAsync(
        [FromRoute, Required] string id,
        [FromBody, Required] UpdatePflanzeCommand command,
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    [ActionName("DeleteOneAsync"), Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOneAsync(
        [FromRoute, Required] Guid id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeletePflanzeCommand {Id = id}, cancellationToken);
        return Ok(id);
    }
}