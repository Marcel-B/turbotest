using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;
public record CreatePflanzeCommand : IRequest<PflanzeDto>
{
    public string Name { get; init; }
    public string Wissenschaftlich { get; init; }
    public string Herkunft { get; init; }
    public Bereich Ph { get; init; }
    public Bereich Gh { get; init; }
    public Bereich Kh { get; init; }
    public Bereich Temperatur { get; init; }
    public string Bereich { get; init; }
    public string Wachstum { get; init; }
    public bool Emers { get; init; }
    public string Schwierigkeitsgrad { get; init; }
    public DateTimeOffset Datum { get; init; }

    private CreatePflanzeCommand(
        string name,
        string wissenschaftlich,
        string herkunft,
        string bereich,
        Bereich ph,
        Bereich kh,
        Bereich gh,
        Bereich temperatur,
        string wachstum,
        bool emers,
        string schwierigkeitsgrad)
    {
        Name = name;
        Wissenschaftlich = wissenschaftlich;
        Herkunft = herkunft;
        Bereich = bereich;
        Ph = ph;
        Kh = kh;
        Gh = gh;
        Temperatur = temperatur;
        Wachstum = wachstum;
        Emers = emers;
        Schwierigkeitsgrad = schwierigkeitsgrad;
    }
}
