namespace com.marcelbenders.Aqua.Application.Dto;

public record AquariumDto(Guid Id, string Name, int Liter, DateTimeOffset Datum);