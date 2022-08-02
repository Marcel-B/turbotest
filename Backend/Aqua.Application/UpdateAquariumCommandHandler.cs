using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdateAquariumCommandHandler : IRequestHandler<UpdateAquariumCommand, AquariumDto>
{
    private readonly IAquariumRepository _repository;

    public UpdateAquariumCommandHandler(
        IAquariumRepository repository)
    {
        _repository = repository;
    }

    public async Task<AquariumDto> Handle(
        UpdateAquariumCommand request,
        CancellationToken cancellationToken)
    {
        var aquarium = new Aquarium
        {
            UserId = request.UserId,
            Id = request.Id,
            Name = request.Name,
            Liter = request.Liter,
            Datum = DateTimeOffset.Now,
        };
        await _repository.UpdateAsync(aquarium, cancellationToken);
        return new AquariumDto(aquarium.Name, aquarium.Liter);
    }
}