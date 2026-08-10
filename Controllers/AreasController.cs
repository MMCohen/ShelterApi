using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.repository;

namespace ShelterApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AreasController : ControllerBase
{
    private readonly IShelterRepository _repository;
    public AreasController(IShelterRepository repository)
    {
        _repository = repository;
    }


    // /api/areas/statistics
    [HttpGet("statistics")]
    public async Task<ActionResult<IEnumerable<AreaStatisticsDto>>> AreasStatisticsAsync()
    {
        var shelters = await _repository.AreasStatisticsAsync();
        return Ok(shelters);
    }



}
