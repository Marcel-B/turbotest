using com.marcelbenders.Aqua.Domain.Sql;

namespace com.marcelbenders.Aqua.Application.Dto;

public record PflanzeDto(Guid Id, string Name, string Wissenschaftlich, string Herkunft, Bereich Ph, Bereich Gh, Bereich Kh, Bereich Temperatur, string Bereich, string Wachstum, bool Emers, string Schwierigkeitsgrad, DateTimeOffset Datum);
