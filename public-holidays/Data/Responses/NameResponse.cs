using System.Text.Json.Serialization;

namespace public_holidays.Data.Responses;

public record NameResponse
{
    [JsonPropertyName("lang")]
    public string Language { get; init; }
    [JsonPropertyName("text")]
    public string Text { get; init; }
}