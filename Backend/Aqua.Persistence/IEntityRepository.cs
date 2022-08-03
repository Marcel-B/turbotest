using com.marcelbenders.Aqua.Domain.Sql;

namespace com.marcelbenders.Aqua.Persistence;

public interface IEntityRepository<T> : IRepository<T> where T : IEntity
{
    Task<IEnumerable<T>> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
}
