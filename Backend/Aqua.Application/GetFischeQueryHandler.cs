using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetFischeQueryHandler : IRequestHandler<GetFischeQuery, IEnumerable<FischDto>>
{
    private readonly IFischRepository _repository;

    public GetFischeQueryHandler(IFischRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FischDto>> Handle(
        GetFischeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}
