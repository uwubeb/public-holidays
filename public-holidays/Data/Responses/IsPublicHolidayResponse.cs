using System.Text.Json.Serialization;

namespace public_holidays.Data.Responses;

public record IsPublicHolidayResponse
{
    [JsonPropertyName("isPublicHoliday")]
    public bool IsPublicHoliday { get; init; }
}