﻿using AutoMapper;
using public_holidays.api;
using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
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
    public async Task<ICollection<GroupedHolidaysDto>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        var holidaysFromDb = await _holidayRepository.GetAllForCountryAndYearAsync(countryCode, year);
        if (holidaysFromDb.Any())
        {
            return GroupHolidays(holidaysFromDb);
        }   
        var holidaysFromApi = await _holidayApiService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        var holidays = _mappper.Map<ICollection<Holiday>>(holidaysFromApi);
        //set holidays country codes with linq
        holidays.ToList().ForEach(h => h.CountryCode = countryCode);
        
        await _holidayRepository.CreateManyAsync(holidays);
        return GroupHolidays(holidays);

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