using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetNotizenQuery(string UserId, long? Number = null) : IRequest<IEnumerable<NotizDto>>;