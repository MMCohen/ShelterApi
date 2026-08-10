using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.repository;

namespace ShelterApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InspectionsController : ControllerBase
{
    private readonly IShelterRepository _repository;
    public InspectionsController(IShelterRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("detailed")]
    public async Task<ActionResult<IEnumerable<InspectionDetailedDto>>> InspectionDetailedAsync()
    {
        var shelters = await _repository.InspectionDetailedAsync();
        return Ok(shelters);
    }

    // /api/inspections/failed
    [HttpGet("failed")]
    public async Task<ActionResult<IEnumerable<FailedInspectionDto>>> FailedInspectionsAsync()
    {
        var shelters = await _repository.FailedInspectionsAsync();
        return Ok(shelters);
    }





}
