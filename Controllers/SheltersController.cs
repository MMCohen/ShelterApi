using Microsoft.AspNetCore.Mvc;
using ShelterApi.Model;
using ShelterApi.DTOs;
using ShelterApi.repository;
using System.Globalization;

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

    [HttpGet("search")]
    public async Task<ActionResult<ShelterSearchResultDto>> SearchAsync( 
        [FromQuery] string? city,
        [FromQuery] int? minCapacity,
        [FromQuery] bool? isAccessible,
        [FromQuery] bool? isPublic
        )
    {
        var shelters = await _repository.SearchAsync(city, minCapacity, isAccessible, isPublic);
        return Ok(shelters);
    }

    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<ShelterSortedDto>>> SheltersSortedAsync(
        [FromQuery] SortByEnum sortBy = SortByEnum.name,
        [FromQuery] bool ascending = true
        )
    {
        var shelters = await _repository.SheltersSortedAsync(sortBy, ascending);
        return Ok(shelters);
    }

}
