using public_holidays.api;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;

namespace public_holidays.Services;

public class HolidayService : IHolidayService
{
    // private readonly IHolidayApi  _holidayApi;
    private readonly HolidayApiService _holidayApiService;
    public HolidayService(HolidayApiService holidayApiService)
    {
        _holidayApiService = holidayApiService;
    }
    public async Task<ICollection<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
    }
    public async Task<DayStatusDto> GetDayStatusAsync(string countryCode,  string year, string month, string day)
    {
        var isWorkDay = await _holidayApiService.IsWorkDayAsync(countryCode, year, month, day);
        var isHoliday = await _holidayApiService.IsPublicHolidayAsync(countryCode, year, month, day);
        return new DayStatusDto
        {
            IsPublicHoliday = isHoliday.IsPublicHoliday,
            IsWorkday = isWorkDay.IsWorkDay,
            isFreeDay = !isWorkDay.IsWorkDay && !isHoliday.IsPublicHoliday
        };
    }
}