using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class DeleteKoralleCommandHandler : IRequestHandler<DeleteKoralleCommand>
{
    private readonly IKoralleRepository _repository;

    public DeleteKoralleCommandHandler(
        IKoralleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(
        DeleteKoralleCommand request,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
