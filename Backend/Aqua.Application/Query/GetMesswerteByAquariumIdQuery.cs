using com.marcelbenders.Aqua.Application.Dto;
using MediatR;

namespace com.marcelbenders.Aqua.Application.Query;

public record GetMesswerteByAquariumIdQuery(Guid AquariumId) : IRequest<AquariumMesswerteDto>;