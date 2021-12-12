namespace SkiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly DataContext _context;

    public ProductsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<Product[]> GetProducts()
    {
        var products = _context.Products.ToList();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _context.Products.SingleOrDefault(p => p.Id == id);

        return Ok(product);
    }
}
