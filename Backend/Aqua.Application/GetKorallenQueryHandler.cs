using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetKorallenQueryHandler : IRequestHandler<GetKorallenQuery, IEnumerable<KoralleDto>>
{
    private readonly IKoralleRepository _repository;

    public GetKorallenQueryHandler(IKoralleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<KoralleDto>> Handle(
        GetKorallenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}