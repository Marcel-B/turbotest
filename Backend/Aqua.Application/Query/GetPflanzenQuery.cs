using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetPflanzenQuery(long? Number = null) : IRequest<IEnumerable<PflanzeDto>>;
