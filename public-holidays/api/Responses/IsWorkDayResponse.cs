using System.Text.Json.Serialization;

namespace public_holidays.api.Responses;

public record IsWorkDayResponse
{
    [JsonPropertyName("isWorkDay")]
    public bool IsWorkDay { get; init; }
}