using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreatePflanzeCommandHandler : IRequestHandler<CreatePflanzeCommand, PflanzeDto>
{
    private readonly IPflanzeRepository _repository;

    public CreatePflanzeCommandHandler(
        IPflanzeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PflanzeDto> Handle(
        CreatePflanzeCommand request,
        CancellationToken cancellationToken)
    {
        var pflanze = new Pflanze
        {
            Name = request.Name,
            Wissenschaftlich = request.Wissenschaftlich,
            Herkunft = request.Herkunft,
            Ph = request.Ph,
            Gh = request.Gh,
            Kh = request.Kh,
            Temperatur = request.Temperatur,
            Bereich = request.Bereich,
            Wachstum = request.Wachstum,
            Emers = request.Emers,
            Schwierigkeitsgrad = request.Schwierigkeitsgrad,
            Datum = request.Datum
        };
        var result = await _repository.CreateAsync(pflanze, cancellationToken);
        return result.BuildDto();
    }
}
