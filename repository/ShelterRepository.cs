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

    public async Task<IEnumerable<SheltersByFilterDTO>> SearchAsync(string? city, int? minCapacity, bool? isAccessible, bool? isPublic)
    {
        var query = _context.Shelters
            .Include(s => s.Area)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query
                .Where(s => s.Area.City == city)
                .AsQueryable();
        }

        if (minCapacity.HasValue)
        {
            query = query
                .Where(s => s.Capacity >= minCapacity)
                .AsQueryable();
        }

        if (isAccessible.HasValue)
        {
            query = query
                .Where(s => s.IsAccessible == isAccessible)
                .AsQueryable();
        }

        if (isPublic.HasValue)
        {
            query = query
                .Where(s => s.IsPublic == isPublic)
                .AsQueryable();
        }

        var shelters = await query
            .Select(s => new SheltersByFilterDTO
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                City = s.Area.City
            })
            .ToListAsync();

        return shelters;
    }
}
