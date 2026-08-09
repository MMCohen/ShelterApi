using Microsoft.AspNetCore.Mvc;
using ShelterApi.Data;
using ShelterApi.DTOs;
using ShelterApi.repository;

namespace ShelterApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SheltersController : ControllerBase
{
    private readonly IShelterRepository _repository;
    public SheltersController(IShelterRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    public ActionResult<string> HelloWorld()
    {
        return Ok("hello world");
    }

    [HttpGet("with-area")]
    public async Task<ActionResult<IEnumerable<SheltersWithAreaDTO>>> SheltersWithArea()
    {
        var shelters = await _repository.SheltersWithAreaAsync();
        return Ok(shelters);
    }

}