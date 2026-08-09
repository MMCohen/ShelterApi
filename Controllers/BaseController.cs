using Microsoft.AspNetCore.Mvc;

namespace ShelterApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShelterController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> HelloWorld()
    {
        return Ok("hello world");
    }
}