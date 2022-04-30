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
    public async Task<IActionResult> GetHolidaysForCountryAndYearAsync()
    {
        var holidays = await _holidayService.GetHolidaysForCountryAndYear();
        return Ok(holidays);
    }
}