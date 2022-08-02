using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateAquariumCommandHandler : IRequestHandler<CreateAquariumCommand, AquariumDto>
{
    private readonly IAquariumRepository _repository;

    public CreateAquariumCommandHandler(
        IAquariumRepository repository)
    {
        _repository = repository;
    }

    public async Task<AquariumDto> Handle(
        CreateAquariumCommand request,
        CancellationToken cancellationToken)
    {
        var aquarium = new Aquarium
        {
            Name = request.Name,
            UserId = request.UserId ?? throw new ArgumentNullException("UserId is null"),
            Liter = request.Liter,
            Datum = DateTimeOffset.Now,
        };
        await _repository.CreateAsync(aquarium, cancellationToken);
        return new AquariumDto(aquarium.Id, aquarium.Name, aquarium.Liter, aquarium.Datum);
    }
}