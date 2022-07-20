using com.marcelbenders.Aqua.Api.Extensions;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Domain.Sql;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;

namespace com.marcelbenders.Aqua.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    /*
    [HttpGet]
    [ActionName("GetAllAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<IFeedItem>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<IFeedItem>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetFeedQuery(HttpContext.GetUserIdentifier(), short.MaxValue),
            cancellationToken);
    }*/

    [HttpGet("Grouped")]
    [ActionName("GetAllGroupedAsync"), Produces("application/json")]
    [ProducesResponseType(typeof(Feed), StatusCodes.Status200OK)]
    public async Task<Feed> GetAllGroupedAsync(
        [FromQuery] short page = 1,
        [FromQuery] short days = 7,
        CancellationToken cancellationToken = default)
    {
        /*
  * This sample pushes a simple application message including a topic and a payload.
  *
  * Always use builders where they exist. Builders (in this project) are designed to be
  * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
  * supported but the class might change often in future releases where the builder does not
  * or at least provides backward compatibility where possible.
  */

        return await _mediator.Send(new GetGroupedFeedQuery(HttpContext.GetUserIdentifier(), days, page),
            cancellationToken);
    }
}