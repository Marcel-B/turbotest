using com.marcelbenders.Aqua.Domain.Sql;

namespace com.marcelbenders.Aqua.Application.Dto;

public record KoralleDto(
    Guid Id,
    string Name,
    string Wissenschaftlich,
    string Herkunft,
    Bereich Salinitaet,
    Bereich Nitrat,
    Bereich Phosphat,
    Bereich Calcium,
    Bereich Magnesium,
    Bereich Kh,
    Bereich Temperatur,
    string Stroemung,
    string Schwierigkeitsgrad,
    string Art,
    DateTimeOffset Datum);