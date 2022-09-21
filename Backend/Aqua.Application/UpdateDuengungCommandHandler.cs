using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdateDuengungCommandHandler : IRequestHandler<UpdateDuengungCommand, DuengungDto>
{
    private readonly IDuengungRepository _repository;

    public UpdateDuengungCommandHandler(
        IDuengungRepository repository)
    {
        _repository = repository;
    }

    public async Task<DuengungDto> Handle(
        UpdateDuengungCommand request,
        CancellationToken cancellationToken)
    {
        var duengung = new Duengung
        {
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            Id = request.Id,
            Menge = request.Menge,
            Datum = request.Datum,
            Duenger = request.Duenger,
            AquariumId = request.AquariumId,
        };
        var result = await _repository.UpdateAsync(duengung, cancellationToken);
        return result.BuildDto();
    }
}