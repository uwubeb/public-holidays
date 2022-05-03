using System.Text.Json.Serialization;

namespace public_holidays.Data.Responses;

public record IsWorkDayResponse
{
    [JsonPropertyName("isWorkDay")]
    public bool IsWorkDay { get; init; }
}