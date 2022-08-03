using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record CreateDuengungCommand : IRequest<DuengungDto>
{
    public double Menge { get; init; }
    public string? UserId { get; set; }
    public DateTimeOffset Datum { get; init; }
    public string Duenger { get; init; }
    public Guid AquariumId { get; init; }
    private CreateDuengungCommand(string duenger, double menge)
    {
        Menge = menge;
        Duenger = duenger;
    }
}