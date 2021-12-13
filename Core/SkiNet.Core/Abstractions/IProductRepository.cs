namespace SkiNet.Core.Abstractions;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);

    Task<IReadOnlyList<Product>> GetProductsAsync();
}