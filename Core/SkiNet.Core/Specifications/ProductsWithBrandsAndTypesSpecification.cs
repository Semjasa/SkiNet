namespace SkiNet.Core.Specifications;

public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
{
    public ProductsWithBrandsAndTypesSpecification(ProductSpecifcationParameters parameters) : base(product => 
        (string.IsNullOrEmpty(parameters.Search) || product.ProductName.ToLower().Contains(parameters.Search)) &&
        (!parameters.BrandId.HasValue || product.ProductBrandId == parameters.BrandId) &&
        (!parameters.TypeId.HasValue || product.ProductTypeId == parameters.TypeId))
    {
        GetSpecifications();

        if (!string.IsNullOrEmpty(parameters.Sort))
        {
            switch (parameters.Sort)
            {
                case "priceAsc":
                    AddOrderBy(product => product.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(product => product.Price);
                    break;
                case "nameAsc":
                    AddOrderBy(product => product.ProductName);
                    break;
                case "nameDesc":
                    AddOrderByDescending(product => product.ProductName);
                    break;
            }
        }

        ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
    }

    public ProductsWithBrandsAndTypesSpecification(int id) : base(product => product.Id == id)
    {
        GetSpecifications();
    }

    private void GetSpecifications()
    {
        AddInclude(product => product.ProductType);
        AddInclude(product => product.ProductBrand);
    }
}
