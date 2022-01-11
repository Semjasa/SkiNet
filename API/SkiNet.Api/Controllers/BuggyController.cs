namespace SkiNet.Api.Controllers;

public class BuggyController : BaseApiController
{
    private readonly DataContext _context;

    public BuggyController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequest()
    {
        var thing = _context.Products.Find(42);

        if (thing == null)
        {
            return NotFound(new ApiResponse(404));
        }

        return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServierErrorRequest()
    {
        var thing = _context.Products.Find(42);

        var thingToReturn = thing.ToString();

        return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequestRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetBadRequestRequest(int id)
    {
        return BadRequest();
    }
}
