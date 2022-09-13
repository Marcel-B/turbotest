using System.ComponentModel.DataAnnotations;

namespace com.marcelbenders.Aqua.Domain;

public class AppUser 
{
    [Key]
    public string UserId { get; set; }
    public virtual ICollection<Duengung> Duengungen { get; set; }
    public virtual ICollection<Messung> Messungen { get; set; }
    public virtual ICollection<Aquarium> Aquarien { get; set; }
    public virtual ICollection<Notiz> Notizen { get; set; }
    public virtual ICollection<Fisch> Fische { get; set; }
    public virtual ICollection<Koralle> Korallen { get; set; }
    public virtual ICollection<Pflanze> Pflanzen { get; set; }
}