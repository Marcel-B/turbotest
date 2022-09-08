using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetKorallenQuery(long? Number = null) : IRequest<IEnumerable<KoralleDto>>;