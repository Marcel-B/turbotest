using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetMesswerteByAquariumIdQueryHandler : IRequestHandler<GetMesswerteByAquariumIdQuery,
    AquariumMesswerteDto>
{
    private readonly IMessungRepository _messungRepository;

    public GetMesswerteByAquariumIdQueryHandler(IMessungRepository messungRepository)
    {
        _messungRepository = messungRepository;
    }

    public async Task<AquariumMesswerteDto?> Handle(GetMesswerteByAquariumIdQuery request,
        CancellationToken cancellationToken)
    {
        var messungen = await _messungRepository.GetMesswerteByAquariumId(request.AquariumId, cancellationToken);
        return new AquariumMesswerteDto(messungen);
    }
}