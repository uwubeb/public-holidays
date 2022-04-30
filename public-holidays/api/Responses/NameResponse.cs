using System.Text.Json.Serialization;

namespace public_holidays.api.Responses;

public record NameResponse
{
    [JsonPropertyName("lang")]
    public int Language { get; init; }
    [JsonPropertyName("text")]
    public int Text { get; init; }
}