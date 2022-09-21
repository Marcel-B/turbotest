using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdateKoralleCommandHandler : IRequestHandler<UpdateKoralleCommand, KoralleDto>
{
    private readonly IKoralleRepository _repository;

    public UpdateKoralleCommandHandler(
        IKoralleRepository repository)
    {
        _repository = repository;
    }

    public async Task<KoralleDto> Handle(
        UpdateKoralleCommand request,
        CancellationToken cancellationToken)
    {
        var koralle = new Koralle
        {
            Id = request.Id,
            Name = request.Name,
            Wissenschaftlich = request.Wissenschaftlich,
            Herkunft = request.Herkunft,
            Salinitaet = request.Salinitaet,
            Nitrat = request.Nitrat,
            Phosphat = request.Phosphat,
            Calcium = request.Calcium,
            Magnesium = request.Magnesium,
            Kh = request.Kh,
            Temperatur = request.Temperatur,
            Stroemung = request.Stroemung,
            Schwierigkeitsgrad = request.Schwierigkeitsgrad,
            Art = request.Art.ToKorallenart(),
            Datum = request.Datum
        };
        var result = await _repository.UpdateAsync(koralle, cancellationToken);
        return result.BuildDto();
    }
}
