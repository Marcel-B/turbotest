using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record UpdateAquariumCommand : CreateAquariumCommand, IRequest<AquariumDto>
{
    public UpdateAquariumCommand()
    {
        
    }
    protected UpdateAquariumCommand(CreateAquariumCommand original) : base(original)
    {
    }

    public Guid Id { get; init; }
}