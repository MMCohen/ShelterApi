using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Data;
using ShelterApi.DTOs;

namespace ShelterApi.repository;

public class ShelterRepository : IShelterRepository
{
    private readonly SheltersDbContext _context;

    public ShelterRepository(SheltersDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SheltersWithAreaDTO>> SheltersWithAreaAsync()
    {
        var shelters = await _context.Shelters
            .Include(s => s.Area)
            .Select(s =>
            new SheltersWithAreaDTO
            {
                ShelterId = s.Id,
                ShelterName = s.Name,
                Capacity = s.Capacity,
                City = s.Area.City,
                Neighborhood = s.Area.Neighborhood
            }
            ).ToListAsync();

        return shelters;
    }
}
