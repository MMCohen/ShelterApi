namespace ShelterApi.DTOs;

public class FailedInspectionDto
{
    public int InspectionId { get; set; }
    public DateTime InspectionDate { get; set; }
    public int ReadinessScore { get; set; }
    public int DefectsCount { get; set; }
    public string ShelterName { get; set; }
    public string City { get; set; }
}
