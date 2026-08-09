using Microsoft.AspNetCore.Mvc;
using ShelterApi.DTOs;

namespace ShelterApi.repository
{
    public interface IShelterRepository
    {
        Task<IEnumerable<SheltersWithAreaDTO>> SheltersWithAreaAsync();
    }
}
