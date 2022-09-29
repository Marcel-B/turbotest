namespace com.marcelbenders.Aqua.Application.Dto;

public record AquariumMessungenWerteDto
{
    public string Messwert { get; }
    public IEnumerable<Tuple<DateTimeOffset, double>> Messungen { get; }

    public AquariumMessungenWerteDto(string messwert, IEnumerable<Tuple<DateTimeOffset, double>> messungen)
    {
        Messungen = messungen.OrderBy(x => x.Item1);
        Messwert = messwert;
    }
}