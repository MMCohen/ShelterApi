using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;
using ShelterApi.Model;

namespace ShelterApi.repository
{
    public interface IShelterRepository
    {
        Task<IEnumerable<SheltersWithAreaDTO>> SheltersWithAreaAsync();
        Task<IEnumerable<ShelterSearchResultDto>> SearchAsync(string? city, int? minCapacity, bool? isAccessible, bool? isPublic);
        Task<IEnumerable<ShelterSortedDto>> SheltersSortedAsync(SortByEnum sortBy, bool ascending);
    }
}
