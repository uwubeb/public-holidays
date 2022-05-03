using System.Text.Json.Serialization;

namespace public_holidays.Data.Responses;

public record SupportedCountryResponse
{
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; init; }
    [JsonPropertyName("fullName")]
    public string Name { get; init; }
}