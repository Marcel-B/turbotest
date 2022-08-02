namespace com.marcelbenders.Aqua.Application.Dto;

public record NotizDto(Guid Id, string Text, string Tag, AquariumDto Aquarium, DateTimeOffset Datum);
