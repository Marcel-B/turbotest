using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetNotizenQueryHandler : IRequestHandler<GetNotizenQuery, IEnumerable<NotizDto>>
{
    private readonly INotizRepository _repository;

    public GetNotizenQueryHandler(INotizRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NotizDto>> Handle(
        GetNotizenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}