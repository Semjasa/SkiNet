namespace SkiNet.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync(ISpecification<T> specification) => 
        await ApplySpecification(specification)
            .CountAsync();

    public async Task<IReadOnlyList<T>> GetAllAync() =>
        await _context
            .Set<T>()
            .ToListAsync();

    public async Task<T> GetByIdAsync(int id) =>
        await _context
            .Set<T>()
            .FindAsync(id);

    public async Task<T> GetEntityWithSecificationAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification)
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification)
            .ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>
            .GetQuery(_context
                .Set<T>()
                .AsQueryable(), specification);
    }
}
