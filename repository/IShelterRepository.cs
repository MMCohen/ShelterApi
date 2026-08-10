using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;

namespace ShelterApi.repository
{
    public interface IShelterRepository
    {
        Task<IEnumerable<SheltersWithAreaDTO>> SheltersWithAreaAsync();
        Task<IEnumerable<SheltersByFilterDTO>> SearchAsync(string? city, int? minCapacity, bool? isAccessible, bool? isPublic);
    }
}
