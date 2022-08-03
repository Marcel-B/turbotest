namespace com.marcelbenders.Aqua.Application.Command;

public record UpdateFischCommand : CreateFischCommand
{
    protected UpdateFischCommand(CreateFischCommand original) : base(original)
    {
    }

    public Guid Id { get; init; }
}