using com.marcelbenders.Aqua.Domain.Sql;

namespace com.marcelbenders.Aqua.Application.Dto;

public record FischDto(Guid Id, string Name, string Wissenschaftlich, string Herkunft, Bereich Ph, Bereich Gh, Bereich Kh, Bereich Temperatur, string Schwimmzone, string Geschlecht, int Anzahl, AquariumDto Aquarium, DateTimeOffset Datum);
