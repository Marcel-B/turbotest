using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdatePflanzeCommandHandler : IRequestHandler<UpdatePflanzeCommand, PflanzeDto>
{
    private readonly IPflanzeRepository _repository;

    public UpdatePflanzeCommandHandler(
        IPflanzeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PflanzeDto> Handle(
        UpdatePflanzeCommand request,
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
        var result = await _repository.UpdateAsync(pflanze, cancellationToken);
        return result.BuildDto();
    }
}