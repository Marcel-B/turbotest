using Aqua.SqlServer.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using Microsoft.EntityFrameworkCore;

namespace com.marcelbenders.Aqua.SqlServer.Repository;

public class MessungRepository : IMessungRepository
{
    private readonly DataContext _context;

    public MessungRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Messung> CreateAsync(Messung entity, CancellationToken cancellationToken)
    {
        _context.CreateAppUserIfNotExist(entity.UserId);
        entity.Id = Guid.NewGuid();
        var result = _context.Messungen.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        await result.Reference(r => r.Aquarium).LoadAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<Messung?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Messungen.FirstOrDefaultAsync(messung => messung.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Messung>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _context.Messungen.Where(messung => messung.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Messung>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Messungen.ToListAsync(cancellationToken);
    }

    public Task<Messung> UpdateAsync(Messung entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Messungen.FirstOrDefaultAsync(messung => messung.Id == id, cancellationToken);
        _context.Entry<Messung>(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Messung>> GetByAquariumId(Guid aquariumId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Messungen.Include(s => s.Aquarium).Where(x => x.AquariumId == aquariumId)
            .OrderBy(x => x.Datum)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<string>> GetMesswerteByAquariumId(Guid aquariumId,
        CancellationToken cancellationToken = default)
        => await _context
            .Messungen
            .Include(s => s.Aquarium)
            .Where(x => x.AquariumId == aquariumId)
            .Select(x => x.Wert)
            .Distinct()
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<Tuple<DateTimeOffset, double>>> GetMessungenByAquariumIdByMesswert(
        Guid aquariumId,
        string messwert,
        CancellationToken cancellationToken = default)
    {
        var result = await _context.Messungen
            .Where(x => x.AquariumId == aquariumId && x.Wert == messwert)
            .Select(x => new Tuple<DateTimeOffset, double>(x.Datum, x.Menge))
            .ToListAsync(cancellationToken);
        return result;
    }
}