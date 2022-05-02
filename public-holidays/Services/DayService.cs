using AutoMapper;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
using public_holidays.Data.Models;
using public_holidays.Repositories;

namespace public_holidays.Services;

public class DayService : IDayService
{
    private readonly HolidayApiService _holidayApiService;
    private readonly IHolidayService _holidayService;
    private readonly IDayRepository _dayRepository;
    private readonly IMapper _mappper;

    public DayService(HolidayApiService holidayApiService, IDayRepository dayRepository, IHolidayService holidayService)
    {
        _holidayApiService = holidayApiService;
        _dayRepository = dayRepository;
        _holidayService = holidayService;
    }

    public async Task<int> GetMaxFreeDaysAsync(string countryCode, string year)
    {
        var yearStart = new DateTime(int.Parse(year), 1, 1);
        var maxFreeDays = 0;
        var currFreeDays = 0;
        var holidays = await _holidayService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        //O(1)
        for (DateTime date = yearStart; date.Year == int.Parse(year); date = date.AddDays(1))
        {
            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday || holidays.Any(h => h.Date == date))
            {
                currFreeDays++;
            }
            else
            {
                maxFreeDays = Math.Max(maxFreeDays, currFreeDays);
                currFreeDays = 0;
            }
        }
        return maxFreeDays;
    }
}