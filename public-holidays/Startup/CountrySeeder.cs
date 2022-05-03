using AutoMapper;
using Microsoft.EntityFrameworkCore;
using public_holidays.Data;
using public_holidays.Data.Dtos;
using public_holidays.Data.Models;
using public_holidays.Repositories;
using public_holidays.Services;

namespace public_holidays.Startup;

public class CountrySeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly HolidayApiService _holidayApiService;
    
    public CountrySeeder(ApplicationDbContext context, IMapper mapper, HolidayApiService holidayApiService)
    {
        _context = context;
        _mapper = mapper;
        _holidayApiService = holidayApiService;
    }

    public async Task SeedCountriesFromApi()
    {
        
        if (!_context.Countries.Any())
        {
            var countriesFromApi = await _holidayApiService.GetSupportedCountriesAsync();
            var countriesModels = _mapper.Map<List<Country>>(countriesFromApi);
            await _context.AddRangeAsync(countriesModels);
            await _context.SaveChangesAsync();
        }
        
    }
}