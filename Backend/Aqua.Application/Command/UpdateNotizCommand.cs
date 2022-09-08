namespace com.marcelbenders.Aqua.Application.Command;

public record UpdateNotizCommand : CreateNotizCommand
{
    public Guid Id { get; set; }

    protected UpdateNotizCommand(CreateNotizCommand original) : base(original) {
    }
}