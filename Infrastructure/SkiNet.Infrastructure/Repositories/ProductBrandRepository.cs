namespace SkiNet.Infrastructure.Repositories;

public class ProductBrandRepository : IProductBrandRepository
{
    private readonly DataContext _context;

    public ProductBrandRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        var productBrands = await _context.ProductBrands.ToListAsync();

        return productBrands;
    }
}
