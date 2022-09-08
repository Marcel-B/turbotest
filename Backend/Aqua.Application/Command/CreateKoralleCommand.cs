using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record CreateKoralleCommand : IRequest<KoralleDto>
{
    public string Name { get; init; }
    public string Wissenschaftlich { get; init; }
    public string Herkunft { get; init; }
    public Bereich Salinitaet { get; init; }
    public Bereich Nitrat { get; init; }
    public Bereich Phosphat { get; init; }
    public Bereich Calcium { get; init; }
    public Bereich Magnesium { get; init; }
    public Bereich Kh { get; init; }
    public Bereich Temperatur { get; init; }
    public string Art { get; init; }
    public string Stroemung { get; init; }
    public string Schwierigkeitsgrad { get; init; }
    public DateTimeOffset Datum { get; init; }

    private CreateKoralleCommand(
        string name,
        string wissenschaftlich,
        string herkunft,
        Bereich salinitaet,
        Bereich nitrat,
        Bereich phosphat,
        Bereich calcium,
        Bereich magnesium,
        Bereich kh,
        Bereich temperatur,
        string art,
        string stroemung,
        string schwierigkeitsgrad)
    {
        Name = name;
        Wissenschaftlich = wissenschaftlich;
        Herkunft = herkunft;
        Salinitaet = salinitaet;
        Nitrat = nitrat;
        Phosphat = phosphat;
        Calcium = calcium;
        Magnesium = magnesium;
        Kh = kh;
        Temperatur = temperatur;
        Art = art;
        Stroemung = stroemung;
        Schwierigkeitsgrad = schwierigkeitsgrad;
    }
}
