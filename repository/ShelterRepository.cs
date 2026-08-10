using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Data;
using ShelterApi.DTOs;
using ShelterApi.Model;

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

    public async Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(string? city, int? minCapacity, bool? isAccessible, bool? isPublic)
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
            .Select(s => new ShelterSearchResultDto
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


    public async Task<IEnumerable<ShelterSortedDto>> SheltersSortedAsync(SortByEnum sortBy, bool ascending)
    {
        var query = _context.Shelters
            .Include(s => s.Area)
            .AsQueryable();

        switch (sortBy)
        {
            case SortByEnum.city:
                if (ascending) { query = query.OrderBy(s => s.Area.City); }
                else { query = query.OrderByDescending(s => s.Area.City); }
                break;

            case SortByEnum.capacity:
                if (ascending) { query = query.OrderBy(s => s.Capacity); }
                else { query = query.OrderByDescending(s => s.Capacity); }
                break;

            case SortByEnum.name:
                if (ascending) { query = query.OrderBy(s => s.Name); }
                else { query = query.OrderByDescending(s => s.Name); }
                break;
        }

        var shelters = await query.
            Select(s => new ShelterSortedDto
            {
                Id = s.Id,
                Name = s.Name,
                Street = s.Street,
                BuildingNumber = s.BuildingNumber,
                Capacity = s.Capacity,
                IsAccessible = s.IsAccessible,
                IsPublic = s.IsPublic,
                ShelterType = s.ShelterType
            })
            .ToListAsync();

        return shelters;
    }

    public async Task<IEnumerable<InspectionDetailedDto>> InspectionDetailedAsync()
    {
        var shelters = await _context.Inspections
            .Include(i => i.Shelter)
            .Include(i => i.Shelter.Area)
            .Select(i => new InspectionDetailedDto
            {
                InspectionId = i.Id,
                InspectionDate = i.InspectionDate,
                ReadinessScore = i.ReadinessScore,
                Passed = i.Passed,
                ShelterName = i.Shelter.Name,
                City = i.Shelter.Area.City,
                Neighborhood = i.Shelter.Area.Neighborhood
            })
            .ToListAsync();

        return shelters;
    }

    public async Task<IEnumerable<ShelterWithInspectionCountDto>> SheltersWithInspectionCountAsync()
    {
        var shelters = await _context.Shelters
            .Include(s => s.Inspections)
            .Select(s => new ShelterWithInspectionCountDto
            {
                ShelterId = s.Id,
                ShelterName = s.Name,
                InspectionCount = s.Inspections.Count
            })
            .ToListAsync();

        return shelters;
    }

}
