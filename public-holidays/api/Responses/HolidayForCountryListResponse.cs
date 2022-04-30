namespace public_holidays.api.Responses;

public record HolidayForCountryListResponse
{
    //bad serializer
    public IReadOnlyCollection<HolidaysForCountryResponse> Holidays { get; init; }
}