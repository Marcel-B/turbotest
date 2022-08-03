using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class CreateDuengungCommandHandler : IRequestHandler<CreateDuengungCommand, DuengungDto>
{
    private readonly IDuengungRepository _repository;

    public CreateDuengungCommandHandler(
        IDuengungRepository repository)
    {
        _repository = repository;
    }

    public async Task<DuengungDto> Handle(
        CreateDuengungCommand request,
        CancellationToken cancellationToken)
    {
        var duengung = new Duengung
        {
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            Menge = request.Menge,
            Datum = request.Datum,
            Duenger = request.Duenger,
            AquariumId = request.AquariumId,
        };
        var result = await _repository.CreateAsync(duengung, cancellationToken);
        return result.BuildDto();
    }
}