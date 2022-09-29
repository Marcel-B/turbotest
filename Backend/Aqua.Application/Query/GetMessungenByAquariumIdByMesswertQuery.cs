using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetMessungenByAquariumIdByMesswertQuery(Guid AquariumId, string messwert): IRequest<AquariumMessungenWerteDto>;