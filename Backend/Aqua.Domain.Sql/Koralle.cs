namespace com.marcelbenders.Aqua.Domain.Sql;

public class Koralle
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Wissenschaftlich { get; set; }
    public string Herkunft { get; set; }
    public Bereich Salinitaet { get; set; }
    public Bereich Nitrat { get; set; }
    public Bereich Phosphat { get; set; }
    public Bereich Calcium { get; set; }
    public Bereich Magnesium { get; set; }
    public Bereich Kh { get; set; }
    public Bereich Temperatur { get; set; }
    public string Stroemung { get; set; }
    public string Schwierigkeitsgrad { get; set; }
    public DateTimeOffset Datum { get; set; }
}