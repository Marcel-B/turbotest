using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record CreateMessungCommand : IRequest<MessungDto>
{
    public string? UserId { get; set; }
    public Guid AquariumId { get; init; }
    public DateTimeOffset Datum { get; init; }
    public double Menge { get; init; }
    public string Wert { get; init; }

    private CreateMessungCommand(
        string wert)
    {
        Wert = wert;
    }
}