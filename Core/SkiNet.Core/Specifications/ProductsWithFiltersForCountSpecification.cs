namespace SkiNet.Core.Specifications;

public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
{
    public ProductsWithFiltersForCountSpecification(ProductSpecifcationParameters parameters) : base(product =>
        (string.IsNullOrEmpty(parameters.Search) || product.ProductName.ToLower().Contains(parameters.Search)) &&
        (!parameters.BrandId.HasValue || product.ProductBrandId == parameters.BrandId) &&
        (!parameters.TypeId.HasValue || product.ProductTypeId == parameters.TypeId))
    {

    }
}
