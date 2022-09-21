using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateFischCommandHandler : IRequestHandler<CreateFischCommand, FischDto>
{
    private readonly IFischRepository _repository;

    public CreateFischCommandHandler(
        IFischRepository repository)
    {
        _repository = repository;
    }

    public async Task<FischDto> Handle(
        CreateFischCommand request,
        CancellationToken cancellationToken)
    {
        var fisch = new Fisch
        {
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            Name = request.Name,
            Wissenschaftlich = request.Wissenschaftlich,
            Herkunft = request.Herkunft,
            Ph = request.Ph,
            Gh = request.Gh,
            Kh = request.Kh,
            Temperatur = request.Temperatur,
            Schwimmzone = request.Schwimmzone,
            Datum = request.Datum,
            Anzahl = request.Anzahl,
            Geschlecht = request.Geschlecht,
            AquariumId = request.AquariumId
        };
        var result = await _repository.CreateAsync(fisch, cancellationToken);
        return result.BuildDto();
    }
}
