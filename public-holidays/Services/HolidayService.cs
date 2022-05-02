using AutoMapper;
using public_holidays.api;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
using public_holidays.Data.Enums;
using public_holidays.Data.Models;
using public_holidays.Repositories;

namespace public_holidays.Services;

public class HolidayService : IHolidayService
{
    private readonly HolidayApiService _holidayApiService;
    private readonly IHolidayRepository  _holidayRepository;
    private readonly IMapper _mappper;
    public HolidayService(HolidayApiService holidayApiService, IMapper mappper, IHolidayRepository holidayRepository)
    {
        _holidayApiService = holidayApiService;
        _mappper = mappper;
        _holidayRepository = holidayRepository;
    }
    public async Task<ICollection<GroupedHolidaysDto>> GetHolidaysForCountryAndYearGroupedAsync(string countryCode, string year)
    {
        var holidaysFromDb = await _holidayRepository.GetAllForCountryAndYearAsync(countryCode, year);
        if (holidaysFromDb.Any())
        {
            return GroupHolidays(holidaysFromDb);
        }
        var holidaysFromApi = await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        var holidays = _mappper.Map<ICollection<Holiday>>(holidaysFromApi);
        
        holidays.ToList().ForEach(h => h.CountryCode = countryCode);
        
        //problem is that this needs countries to be already in db, because it uses their foreign keys.
        //gonna just seed data.
        try
        {
            await _holidayRepository.CreateManyAsync(holidays);
        }
        catch (Exception e)
        {
            //ignore for now
        }
        return GroupHolidays(holidays);

    }
  
    public async Task<DayStatusDto> GetDayStatusAsync(string countryCode,  string year, string month, string day)
    {
        // Not using api's isPublicHoliday or isWorkDay because it would make the api call twice
        // while my implementation has max 1 call, or 0 if we already have the holidays in db
        
        var date = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        
        // this is just to make sure that we have all the holidays for the year in our db
        // so we don't need to make repeated calls to the api and instead can use repo 
        var _ = await GetHolidaysForCountryAndYearAsync(countryCode, year);
        var holiday = await _holidayRepository.GetByCountryAndDateAsync(countryCode, date);
        DayStatus status;
        if (holiday is not null)
        {
            status = DayStatus.PublicHoliday;
        }
        else if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            status = DayStatus.Weekend;
        }
        else
        {
            status = DayStatus.WorkingDay;
        }
        return new DayStatusDto
        {
           Status = status
        };
    }
    public async Task<ICollection<HolidayDto>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        var holidaysFromDb = await _holidayRepository.GetAllForCountryAndYearAsync(countryCode, year);
        List<HolidayDto> holidays;
        if (holidaysFromDb.Any())
        {
            holidays = _mappper.Map<List<HolidayDto>>(holidaysFromDb);
            return holidays;
        }
        var holidaysFromApi = await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        holidays = _mappper.Map<List<HolidayDto>>(holidaysFromApi);
        return holidays;
    }
    
    public async Task<int> GetMaxFreeDaysForCountryAndYearAsync(string countryCode, string year)
    {
        //we're making an assumption that mon-fri are workdays except for national holidays
        var yearStart = new DateTime(int.Parse(year), 1, 1);
        var maxFreeDays = 0;
        var currFreeDays = 0;
        var holidays = await GetHolidaysForCountryAndYearAsync(countryCode, year);
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
    
    private ICollection<GroupedHolidaysDto> GroupHolidays(ICollection<Holiday> holidaysFromDb)
    {
        var holidaysByDate = holidaysFromDb.GroupBy(x => x.Date.Month);
        return holidaysByDate.Select(x => new GroupedHolidaysDto()
        {
            Month = x.Key,
            Holidays = _mappper.Map<List<HolidayDto>>(x)
        }).ToList();
    }
}
