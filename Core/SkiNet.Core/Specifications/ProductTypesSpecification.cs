namespace SkiNet.Core.Specifications;

public class ProductTypesSpecification : BaseSpecification<ProductType>
{
    public ProductTypesSpecification()
    {
    }

    public ProductTypesSpecification(int id) : base(type => type.Id == id)
    {
    }
}
