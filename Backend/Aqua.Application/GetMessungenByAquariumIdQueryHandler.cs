using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
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
        var header = messungen.Select(x => x.Wert).Distinct();
        var groupedMessungen = messungen.Select(m => new
        {
            Datum = new DateTimeOffset(m.Datum.Year, m.Datum.Month, m.Datum.Day, 12, 0, 0, m.Datum.Offset),
            Wert = m.Wert,
            Menge = m.Menge,
            Name = m.Aquarium.Name
        }).GroupBy(x => x.Datum);

        var timestampDtos = new List<TimestampDto<AquariumMessungDto>>();

        foreach (var messung in groupedMessungen)
        {
            var mess = messung.ToList();
            var tmp = new List<AquariumMessungDto>();
            foreach (var head in header)
            {
                var value = mess.FirstOrDefault(x => x.Wert == head);
                tmp.Add(new AquariumMessungDto(head, value?.Menge));
            }
            timestampDtos.Add(new TimestampDto<AquariumMessungDto>(messung.Key, tmp));
        }

        return new AquariumMessungenDto(aquarium.Id, aquarium.Name, aquarium.Liter, header, timestampDtos);
    }
}