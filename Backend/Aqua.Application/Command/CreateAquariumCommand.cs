using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record CreateAquariumCommand : IRequest<AquariumDto>
{
    public string Name { get; init; }
    public int Liter { get; init; }

    public string? UserId { get; set; }
    
    public DateTimeOffset Datum { get; init; }

    public CreateAquariumCommand()
    {
    }

    private CreateAquariumCommand(
        string name,
        int liter)
    {
        Name = name;
        Liter = liter;
    }
}