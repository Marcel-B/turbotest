namespace com.marcelbenders.Aqua.Application.Dto;

public record AquariumMessungDto(string Wert, double? Menge);

public record TimestampDto<T>(DateTimeOffset Datum, IEnumerable<T> Messungen);

public record AquariumMessungenDto(
    Guid Id,
    string Name,
    double Liter,
    IEnumerable<string> Header,
    IEnumerable<TimestampDto<AquariumMessungDto>> Timestamps);