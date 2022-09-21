using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;

namespace com.marcelbenders.Aqua.Application.Extensions;

public static class DtoBuilderExtensions
{
    public static AquariumDto BuildDto(this Aquarium source)
        => new AquariumDto(source.Id, source.Name, source.Liter, source.Datum);

    public static DuengungDto BuildDto(this Duengung source)
        => new DuengungDto(source.Id, source.Duenger, source.Menge, source.Aquarium.BuildDto(), source.Datum);

    public static NotizDto BuildDto(this Notiz soruce)
        => new NotizDto(soruce.Id, soruce.Text, soruce.Tag, soruce.Aquarium.BuildDto(), soruce.Datum);

    public static MessungDto BuildDto(this Messung source)
        => new MessungDto(source.Id, source.Wert, source.Menge, source.Aquarium.BuildDto(), source.Datum);

    public static FischDto BuildDto(this Fisch source)
        => new FischDto(source.Id, source.Name, source.Wissenschaftlich, source.Herkunft, source.Ph, source.Gh,
            source.Kh, source.Temperatur, source.Schwimmzone, source.Geschlecht, source.Anzahl,
            source.Aquarium.BuildDto(), source.Datum);

    public static PflanzeDto BuildDto(this Pflanze source)
        => new PflanzeDto(source.Id, source.Name, source.Wissenschaftlich, source.Herkunft, source.Ph, source.Gh,
            source.Kh, source.Temperatur, source.Bereich, source.Wachstum, source.Emers, source.Schwierigkeitsgrad,
            source.Datum);

    private static string Parse(this Korallenart art)
        => art switch
        {
            Korallenart.Gorgonie => "Gorgonie",
            Korallenart.Leder => "Lederkoralle",
            Korallenart.Lps => "LPS",
            Korallenart.Sps => "SPS",
            Korallenart.Weich => "Weichkoralle",
            _ => throw new NotImplementedException("Unbekannte Korallenart")
        };

    public static Korallenart ToKorallenart(this string art)
        => art switch
        {
            "Gorgonie" => Korallenart.Gorgonie,
            "Lederkoralle" => Korallenart.Leder,
            "LPS" => Korallenart.Lps,
            "SPS" => Korallenart.Sps,
            "Weichkoralle" => Korallenart.Weich,
            _ => throw new NotImplementedException($"Art {art} ist nicht bekannt")
        };

    public static KoralleDto BuildDto(this Koralle source)
        => new KoralleDto(source.Id, source.Name, source.Wissenschaftlich, source.Herkunft, source.Salinitaet,
            source.Nitrat, source.Phosphat, source.Calcium, source.Magnesium, source.Kh, source.Temperatur,
            source.Stroemung, source.Schwierigkeitsgrad, source.Art.Parse(), source.Datum);
}