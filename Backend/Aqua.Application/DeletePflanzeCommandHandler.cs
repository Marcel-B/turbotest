using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class DeletePflanzeCommandHandler : IRequestHandler<DeletePflanzeCommand>
{
    private readonly IPflanzeRepository _repository;

    public DeletePflanzeCommandHandler(
        IPflanzeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(
        DeletePflanzeCommand request,
        CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}