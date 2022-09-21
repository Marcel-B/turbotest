using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetMessungenQueryHandler : IRequestHandler<GetMessungenQuery, IEnumerable<MessungDto>>
{
    private readonly IMessungRepository _repository;

    public GetMessungenQueryHandler(IMessungRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MessungDto>> Handle(GetMessungenQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}