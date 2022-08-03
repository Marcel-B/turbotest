using Aqua.Application.Extensions;
using com.marcelbenders.Aqua.Application.Dto;
using com.marcelbenders.Aqua.Application.Query;
using com.marcelbenders.Aqua.Persistence;
using MediatR;

namespace com.marcelbenders.Aqua.Application;

public class GetPflanzenQueryHandler : IRequestHandler<GetPflanzenQuery, IEnumerable<PflanzeDto>>
{
    private readonly IPflanzeRepository _repository;

    public GetPflanzenQueryHandler(IPflanzeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PflanzeDto>> Handle(
        GetPflanzenQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(cancellationToken);
        return result.Select(x => x.BuildDto());
    }
}