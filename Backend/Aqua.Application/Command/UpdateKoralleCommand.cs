namespace com.marcelbenders.Aqua.Application.Command;

public record UpdateKoralleCommand : CreateKoralleCommand
{
    protected UpdateKoralleCommand(CreateKoralleCommand original) : base(original)
    {
    }
    public Guid Id { get; set; }
}