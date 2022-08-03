using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Command;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Domain.Sql;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class UpdateMessungCommandHandler : IRequestHandler<UpdateMessungCommand, MessungDto>
{
    private readonly IMessungRepository _repository;

    public UpdateMessungCommandHandler(
        IMessungRepository repository)
    {
        _repository = repository;
    }

    public async Task<MessungDto> Handle(UpdateMessungCommand request, CancellationToken cancellationToken)
    {
        var messung = new Messung
        {
            UserId = request.UserId ?? throw new NullReferenceException("Missing UserId"),
            Id = request.Id,
            AquariumId = request.AquariumId,
            Datum = request.Datum,
            Menge = request.Menge,
            Wert = request.Wert
        };
        var result = await _repository.UpdateAsync(messung, cancellationToken);
        return result.BuildDto();
    }
}