using System.Text.Json.Serialization;

namespace ShelterApi.Model;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortByEnum
{
    capacity,
    name,
    city
}
