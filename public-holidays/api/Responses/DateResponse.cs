using System.Text.Json.Serialization;

namespace public_holidays.api.Responses;

public record DateResponse
{
    [JsonPropertyName("day")]
    public int Day { get; init; }
    [JsonPropertyName("month")]
    public int Month { get; init; }
    [JsonPropertyName("year")]
    public int Year { get; init; }
    [JsonPropertyName("dayOfWeek")]
    public int DayOfWeek { get; init; }
}