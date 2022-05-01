using System.Text.Json.Serialization;

namespace public_holidays.api.Responses;

public record IsPublicHolidayResponse
{
    [JsonPropertyName("isPublicHoliday")]
    public bool IsPublicHoliday { get; init; }
}