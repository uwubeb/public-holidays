using Microsoft.AspNetCore.Mvc;
using public_holidays.Data.Queries;
using public_holidays.Services;

namespace public_holidays.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HolidaysController : ControllerBase
{
    private readonly IHolidayService _holidayService;
    // Need proper exception handling, I think it's outside the scope.
    private const string _errorMessage = "Something went wrong. Please try changing your query or try again later.";
    public HolidaysController(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHolidaysForCountryAndYearAsync([FromQuery] CountryYearQueryParams queryParams)
    {
        try
        {
            var holidays = await _holidayService.
                GetHolidaysForCountryAndYearGroupedAsync(queryParams.CountryCode, queryParams.Year.ToString());
            return Ok(holidays);
        }
        catch (Exception ex)
        {
            return BadRequest(_errorMessage);
        }
      
    }
    
    [HttpGet("dayStatus")]
    public async Task<IActionResult> GetDayStatusForCountryDateAsync([FromQuery] CountryDateQueryParams queryParams)
    {
        try
        {
            var holiday = await _holidayService.GetDayStatusAsync(queryParams.CountryCode,
            queryParams.Year.ToString(), queryParams.Month.ToString(), queryParams.Day.ToString());
            return Ok(holiday);
        }
        catch (Exception ex)
        {
            return BadRequest(_errorMessage);
        }
        
    }
    
    [HttpGet("maxFreeDays")]
    public async Task<IActionResult> GetMaxFreeDaysForCountryAndYearAsync([FromQuery] CountryYearQueryParams queryParams)
    {
        try
        {
            var maxFreeDays = await _holidayService.GetMaxFreeDaysForCountryAndYearAsync(queryParams.CountryCode,
            queryParams.Year.ToString());
            return Ok(maxFreeDays);
        }
        catch (Exception ex)
        {
            return BadRequest(_errorMessage);
        }
       
    }
}