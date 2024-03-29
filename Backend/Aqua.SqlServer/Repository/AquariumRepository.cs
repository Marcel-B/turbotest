using Aqua.SqlServer.Extensions;
using com.marcelbenders.Aqua.Domain;
using com.marcelbenders.Aqua.Persistence;
using Microsoft.EntityFrameworkCore;

namespace com.marcelbenders.Aqua.SqlServer.Repository;

public class AquariumRepository : IAquariumRepository
{
    private readonly DataContext _context;

    public AquariumRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Aquarium> CreateAsync(Aquarium entity, CancellationToken cancellationToken)
    {
        _context.CreateAppUserIfNotExist(entity.UserId);
        entity.Datum = DateTimeOffset.Now;
        entity.Id = Guid.NewGuid();
        _context.Aquarien.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Aquarium?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Aquarien.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Aquarium>> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _context.Aquarien.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Aquarium>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Aquarien.ToListAsync(cancellationToken);
    }

    public async Task<Aquarium> UpdateAsync(
        Aquarium entity,
        CancellationToken cancellationToken)
    {
        _context.CreateAppUserIfNotExist(entity.UserId);
        var aquariumDb = await _context.Aquarien.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);
        aquariumDb.Liter = entity.Liter;
        aquariumDb.Name = entity.Name;
        await _context.SaveChangesAsync(cancellationToken);
        return aquariumDb;
    }

    public async Task DeleteAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var aquarium = await GetByIdAsync(id, cancellationToken);
        if (aquarium is not null)
        {
            _context.Entry(aquarium).State = EntityState.Deleted;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}