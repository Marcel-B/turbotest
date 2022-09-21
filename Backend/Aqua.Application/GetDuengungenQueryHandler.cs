using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetDuengungenQueryHandler : IRequestHandler<GetDuengungenQuery, IEnumerable<DuengungDto>>
{
    private readonly IDuengungRepository _repository;

    public GetDuengungenQueryHandler(IDuengungRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DuengungDto>> Handle(
        GetDuengungenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}