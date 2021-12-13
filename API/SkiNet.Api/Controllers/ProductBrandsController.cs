namespace SkiNet.Api.Controllers;

public class ProductBrandsController : BaseController
{
    private readonly IProductBrandRepository _productBrandRepository;

    public ProductBrandsController(IProductBrandRepository productBrandRepository)
    {
        _productBrandRepository = productBrandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> Index()
    {
        var productBrands = await _productBrandRepository.GetProductBrandsAsync();

        return Ok(productBrands);
    }
}
