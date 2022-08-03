using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record DeletePflanzeCommand : IRequest
{
    public Guid Id { get; init; }
}
