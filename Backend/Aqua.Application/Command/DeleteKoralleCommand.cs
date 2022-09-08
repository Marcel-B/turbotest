using MediatR;

namespace com.marcelbenders.Aqua.Application.Command;

public record DeleteKoralleCommand : IRequest
{
    public Guid Id { get; init; }
}