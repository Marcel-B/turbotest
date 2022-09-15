using com.marcelbenders.Aqua.Domain;

namespace com.marcelbenders.Aqua.Persistence;

public interface IMessungRepository : IEntityRepository<Messung>
{
    Task<IEnumerable<Messung>> GetByAquariumId(Guid aquariumId, CancellationToken cancellationToken = default);
}