using System.Text.Json.Serialization;

namespace public_holidays.api.Responses;

public record HolidaysForCountryResponse
{
    [JsonPropertyName("date")]
    public DateResponse Date { get; init; }
    [JsonPropertyName("name")]
    public ICollection<NameResponse> Names { get; init; }
}