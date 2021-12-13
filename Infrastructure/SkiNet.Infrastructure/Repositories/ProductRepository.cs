namespace SkiNet.Infrastructure.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(product => product.ProductBrand)
            .Include(product => product.ProductType)
            .SingleOrDefaultAsync(product => product.Id == id);

        return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await _context.Products
            .Include(product => product.ProductBrand)
            .Include(product => product.ProductType)
            .ToListAsync();

        return products;
    }
}