namespace com.marcelbenders.Aqua.Application.Dto;

public record MessungDto(Guid Id, string Wert, double Menge, AquariumDto Aquarium, DateTimeOffset Datum);