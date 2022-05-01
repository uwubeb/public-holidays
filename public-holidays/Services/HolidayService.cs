using public_holidays.api;
using public_holidays.api.Responses;

namespace public_holidays.Services;

public class HolidayService : IHolidayService
{
    // private readonly IHolidayApi  _holidayApi;
    private readonly HolidayApiService _holidayApiService;
    public HolidayService(HolidayApiService holidayApiService)
    {
        _holidayApiService = holidayApiService;
    }
    public async Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
    }
}