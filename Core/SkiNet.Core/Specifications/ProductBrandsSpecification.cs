namespace SkiNet.Core.Specifications;

public class ProductBrandsSpecification : BaseSpecification<ProductBrand>
{
    public ProductBrandsSpecification()
    {        
    }

    public ProductBrandsSpecification(int id) : base(brand => brand.Id == id)
    {
    }
}
