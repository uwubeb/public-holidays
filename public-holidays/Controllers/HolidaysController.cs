using Microsoft.AspNetCore.Mvc;
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
        var holidays = await _holidayService.GetHolidaysForCountryAndYearGroupedAsync(countryCode, year);
        return Ok(holidays);
    }
    
    [HttpGet("dayStatus")]
    public async Task<IActionResult> GetDayStatusForCountryDateAsync([FromQuery] string countryCode,[FromQuery] string year,[FromQuery] string month,[FromQuery] string day)
    {
        // var date = DateTime.TryParse(year, month, day, out var dateTime);
        var holiday = await _holidayService.GetDayStatusAsync(countryCode, year, month, day);
        return Ok(holiday);
    }
    
    [HttpGet("maxFreeDays")]
    public async Task<IActionResult> GetMaxFreeDaysForCountryAndYearAsync([FromQuery] string countryCode,[FromQuery] string year)
    {
        var maxFreeDays = await _holidayService.GetMaxFreeDaysForCountryAndYearAsync(countryCode, year);
        return Ok(maxFreeDays);
    }
}