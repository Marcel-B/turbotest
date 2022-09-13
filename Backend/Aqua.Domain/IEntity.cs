namespace com.marcelbenders.Aqua.Domain;

public interface IEntity
{
    public Guid Id { get; set; }
    public string UserId { get; set; }    
}