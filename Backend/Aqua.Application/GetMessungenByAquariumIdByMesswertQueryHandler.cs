using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetMessungenByAquariumIdByMesswertQueryHandler : IRequestHandler<GetMessungenByAquariumIdByMesswertQuery,
    AquariumMessungenWerteDto>
{
    private readonly IMessungRepository _messungRepository;

    public GetMessungenByAquariumIdByMesswertQueryHandler(IMessungRepository messungRepository)
    {
        _messungRepository = messungRepository;
    }

    public async Task<AquariumMessungenWerteDto?> Handle(
        GetMessungenByAquariumIdByMesswertQuery request,
        CancellationToken cancellationToken)
    {
        var messungen = await _messungRepository.GetMessungenByAquariumIdByMesswert(
            request.AquariumId,
            request.messwert,
            cancellationToken);

        return new AquariumMessungenWerteDto(request.messwert, messungen);
    }
}