namespace com.marcelbenders.Aqua.Application.Command;

public record UpdatePflanzeCommand : CreatePflanzeCommand
{
    protected UpdatePflanzeCommand(CreatePflanzeCommand original) : base(original)
    {
    }
    public Guid Id { get; init; }
}
