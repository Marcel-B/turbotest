using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetMessungenByAquariumIdQuery(Guid AquariumId) : IRequest<AquariumMessungenDto>;