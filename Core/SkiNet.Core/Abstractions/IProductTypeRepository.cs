namespace SkiNet.Core.Abstractions;

public interface IProductTypeRepository
{
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}
