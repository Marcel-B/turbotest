using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;

namespace Aqua.Application.Extensions;

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
        => new FischDto(source.Id, source.Name, source.Wissenschaftlich, source.Herkunft, source.Ph, source.Gh, source.Kh, source.Temperatur, source.Schwimmzone, source.Geschlecht, source.Anzahl, source.Aquarium.BuildDto(), source.Datum);

    public static PflanzeDto BuildDto(this Pflanze source)
        => new PflanzeDto(source.Id, source.Name, source.Wissenschaftlich, source.Herkunft, source.Ph, source.Gh, source.Kh, source.Temperatur, source.Bereich, source.Wachstum, source.Emers, source.Schwierigkeitsgrad, source.Datum);
}
