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

    
    [HttpGet]
    public async Task<IActionResult> GetCountriesAsync(CancellationToken cancellationToken)
    {   
       var countries = await _countryService.GetAllAsync(cancellationToken);
       return Ok(countries);
    }   
}