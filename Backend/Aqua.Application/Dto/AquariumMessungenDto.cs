namespace com.marcelbenders.Aqua.Application.Dto;

public record AquariumMessungDto(string Wert, double Menge);
public record AquariumMessungenDto(Guid Id, string Name, double Liter,
    Dictionary<DateTimeOffset, IEnumerable<AquariumMessungDto>> Messungen);