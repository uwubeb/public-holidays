using public_holidays.api;
using public_holidays.api.Responses;

namespace public_holidays.Services;

public class HolidayService : IHolidayService
{
    private readonly IHolidayApi  _holidayApi;
    
    public HolidayService(IHolidayApi holidayApi)
    {
        _holidayApi = holidayApi;
    }

    public async Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _holidayApi.GetHolidaysForCountryAndYearAsync(countryCode, year);
    }
}