namespace SkiNet.Api.Controllers;

public class ProductTypesController : BaseController
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypesController(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var productTypes = await _productTypeRepository.GetProductTypesAsync();

        return Ok(productTypes);
    }
}
