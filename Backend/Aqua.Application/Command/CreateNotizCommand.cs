using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public class CreateNotizCommand : IRequest<NotizDto>
{
    public string? UserId { get; set; }
    public string Text { get; init; }
    public DateTimeOffset Datum { get; init; }
    public string Tag { get; init; }
    public Guid AquariumId { get; init; }
}