namespace SkiNet.Infrastructure.Repositories;

public class ProductTypesRepository : IProductTypeRepository
{
    private readonly DataContext _context;

    public ProductTypesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        var productTypes = await _context.ProductTypes.ToListAsync();

        return productTypes;
    }
}
