using System.ComponentModel.DataAnnotations;

namespace ShelterApi.Model;

public class Area
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string Neighborhood { get; set; } = string.Empty;


    [Required]
    [MaxLength(20)]
    public string AreaCode { get; set; } = string.Empty;

    [Required]
    [Range(1, 5)]
    public int RiskLevel { get; set; }

    public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();
}
