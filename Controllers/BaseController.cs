using Microsoft.AspNetCore.Mvc;
using ShelterApi.Data;

namespace ShelterApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShelterController : ControllerBase
{
    private readonly SheltersDbContext _context;
    public ShelterController(SheltersDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public ActionResult<string> HelloWorld()
    {
        return Ok("hello world");
    }


}