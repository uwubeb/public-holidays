using public_holidays.Data.Models;
using public_holidays.Repositories;

namespace public_holidays.Services;

public class DayService : IDayService
{
    private readonly HolidayApiService _holidayApiService;
    private readonly IDayRepository _dayRepository;
    public DayService(HolidayApiService holidayApiService, IDayRepository dayRepository)
    {
        _holidayApiService = holidayApiService;
        _dayRepository = dayRepository;
    }

    public async Task<int> GetMaxFreeDaysAsync(string countryCode, string year)
    {
        //because different countries have different workweeks, we need to check for every day
        var yearStart = new DateTime(int.Parse(year), 1, 1);
        var maxFreeDays = 0;
        var currFreeDays = 0;
        bool isWorkDay;
        for (DateTime date = yearStart; date.Year == int.Parse(year); date = date.AddDays(1))
        {
            Day day = new Day
            {
                Date = date,
                CountryCode = countryCode,
            };
            var isWorkDayFromDb = _dayRepository.IsWorkDay(day);
            if (isWorkDayFromDb is null)
            {
                var isWorkDayResponse = await _holidayApiService.IsWorkDayAsync(countryCode, date.Year.ToString(), date.Month.ToString(), date.Day.ToString());
                isWorkDay = isWorkDayResponse.IsWorkDay;
                day.IsWorkDay = isWorkDay;
                await _dayRepository.CreateDayAsync(day);
            }
            else
            {
                isWorkDay = isWorkDayFromDb.Value;
            }
            if (!isWorkDay)
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