namespace SkiNet.Core.Abstractions;

public interface IProductBrandRepository
{
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
}
