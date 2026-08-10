namespace ShelterApi.DTOs;

public class AreaStatisticsDto
{
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public int ShelterCount { get; set; }
    public int TotalCapacity { get; set; }
}
