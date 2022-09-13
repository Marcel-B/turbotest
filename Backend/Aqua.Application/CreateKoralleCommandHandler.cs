using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateKoralleCommandHandler : IRequestHandler<CreateKoralleCommand, KoralleDto>
{
    private readonly IKoralleRepository _repository;

    public CreateKoralleCommandHandler(
        IKoralleRepository repository)
    {
        _repository = repository;
    }

    public async Task<KoralleDto> Handle(
        CreateKoralleCommand request,
        CancellationToken cancellationToken)
    {
        var koralle = new Koralle
        {
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
        var result = await _repository.CreateAsync(koralle, cancellationToken);
        return result.BuildDto();
    }
}
