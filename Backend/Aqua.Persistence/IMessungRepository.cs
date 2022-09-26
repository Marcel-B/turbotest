using com.marcelbenders.Aqua.Domain;

namespace com.marcelbenders.Aqua.Persistence;

public interface IMessungRepository : IEntityRepository<Messung>
{
    Task<IEnumerable<Messung>> GetByAquariumId(Guid aquariumId, CancellationToken cancellationToken = default);

    Task<IEnumerable<string>> GetMesswerteByAquariumId(Guid aquariumId, CancellationToken cancellationToken = default);

    Task<IEnumerable<Tuple<DateTimeOffset, double>>> GetMessungenByMesswertAquariumId(Guid aquariumId, string messwert,
        CancellationToken cancellationToken = default);
}