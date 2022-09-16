using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetMessungenByAquariumIdQueryHandler : IRequestHandler<GetMessungenByAquariumIdQuery,
    AquariumMessungenDto>
{
    private readonly IMessungRepository _messungRepository;

    public GetMessungenByAquariumIdQueryHandler(IMessungRepository messungRepository)
    {
        _messungRepository = messungRepository;
    }

    public async Task<AquariumMessungenDto?> Handle(GetMessungenByAquariumIdQuery request,
        CancellationToken cancellationToken)
    {
        var messungen = await _messungRepository.GetByAquariumId(request.AquariumId, cancellationToken);
        if (!messungen.Any())
        {
            return null;
        }

        var aquarium = messungen.FirstOrDefault()?.Aquarium;
        var groupedMessungen = messungen.Select(m => new
        {
            Datum = new DateTimeOffset(m.Datum.Year, m.Datum.Month, m.Datum.Day, 12, 0, 0, m.Datum.Offset),
            Wert = m.Wert,
            Menge = m.Menge,
            Name = m.Aquarium.Name
        }).GroupBy(x => x.Datum);

        var dictionary = new List<TimestampDto<AquariumMessungDto>>();

        foreach (var messung in groupedMessungen)
        {
            dictionary.Add(new TimestampDto<AquariumMessungDto>(messung.Key,
                messung.ToList().Select(x => new AquariumMessungDto(x.Wert, x.Menge))));
        }

        return new AquariumMessungenDto(aquarium.Id, aquarium.Name, aquarium.Liter, dictionary);
    }
}