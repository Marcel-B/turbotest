using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetAquarienQueryHandler : IRequestHandler<GetAquarienQuery, IEnumerable<AquariumDto>>
{
    private readonly IAquariumRepository _repository;

    public GetAquarienQueryHandler(IAquariumRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AquariumDto>> Handle(
        GetAquarienQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}