using ShelterApi.Model;

namespace ShelterApi.DTOs
{
    public class ShelterSortedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsAccessible { get; set; }
        public bool IsPublic { get; set; }
        public ShelterType ShelterType { get; set; }
    }
}
