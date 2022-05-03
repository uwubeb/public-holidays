using Microsoft.AspNetCore.Mvc;
using public_holidays.Services;

namespace public_holidays.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<IActionResult> GetSupportedCountriesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var countries = await _countryService.GetAllAsync(cancellationToken);
            return Ok(countries);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
        
    }   
}