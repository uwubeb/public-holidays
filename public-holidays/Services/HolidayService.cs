using AutoMapper;
using public_holidays.api;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;

namespace public_holidays.Services;

public class HolidayService : IHolidayService
{
    // private readonly IHolidayApi  _holidayApi;
    private readonly HolidayApiService _holidayApiService;
    private readonly IMapper _mappper;
    public HolidayService(HolidayApiService holidayApiService, IMapper mappper)
    {
        _holidayApiService = holidayApiService;
        _mappper = mappper;
    }
    public async Task<ICollection<GroupedHolidaysDto>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        var holidays = await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        //group holidays by date and return a list of holidays for each date
        var holidaysByDate = holidays.GroupBy(x => x.Date.Month);
        return holidaysByDate.Select(x => new GroupedHolidaysDto()
        {
            Month = x.Key,
            Holidays = _mappper.Map<List<HolidaysForCountryResponse>>(x)
        }).ToList();

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