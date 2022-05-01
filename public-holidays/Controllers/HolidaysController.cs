﻿using Microsoft.AspNetCore.Mvc;
using public_holidays.Services;

namespace public_holidays.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HolidaysController : ControllerBase
{
    private readonly IHolidayService _holidayService;

    public HolidaysController(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHolidaysForCountryAndYearAsync([FromQuery] string countryCode,[FromQuery] string year)
    {
        var holidays = await _holidayService.GetHolidaysForCountryAndYearAsync(countryCode, year);
        return Ok(holidays);
    }
    
    [HttpGet("dayStatus")]
    public async Task<IActionResult> GetDayStatusForCountryAsync([FromQuery] string countryCode,[FromQuery] string year,[FromQuery] string month,[FromQuery] string day)
    {
        // var date = DateTime.TryParse(year, month, day, out var dateTime);
        var holiday = await _holidayService.GetDayStatusAsync(countryCode, year, month, day);
        return Ok(holiday);
    }
}