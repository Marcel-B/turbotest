using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateMessungCommandHandler : IRequestHandler<CreateMessungCommand, MessungDto>
{
    private readonly IMessungRepository _repository;

    public CreateMessungCommandHandler(
        IMessungRepository repository)
    {
        _repository = repository;
    }

    public async Task<MessungDto> Handle(CreateMessungCommand request, CancellationToken cancellationToken)
    {
        var messung = new Messung
        {
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            AquariumId = request.AquariumId,
            Datum = request.Datum,
            Menge = request.Menge,
            Wert = request.Wert
        };
        var result = await _repository.CreateAsync(messung, cancellationToken);
        return result.BuildDto();
    }
}