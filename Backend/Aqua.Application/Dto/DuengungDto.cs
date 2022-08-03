namespace com.marcelbenders.Aqua.Application.Dto;

public record DuengungDto(Guid Id, string Duenger, double Menge, AquariumDto Aquarium, DateTimeOffset Datum);
