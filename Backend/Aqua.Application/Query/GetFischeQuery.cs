using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetFischeQuery(string UserId, long? Number = null) : IRequest<IEnumerable<FischDto>>;
