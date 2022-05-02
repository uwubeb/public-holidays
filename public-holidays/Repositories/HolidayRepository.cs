using Microsoft.EntityFrameworkCore;
using public_holidays.Data;
using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public class HolidayRepository : IHolidayRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public HolidayRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ICollection<Holiday>> CreateManyAsync(ICollection<Holiday> holidays)
    {
        await _dbContext.Holidays.AddRangeAsync(holidays);
        await _dbContext.SaveChangesAsync();
        return holidays;
    }
    public async Task<ICollection<Holiday>> GetAllForCountryAndYearAsync(string countryCode, string year)
    {
        //get all holidays for a country and year
        var holidays = _dbContext.Holidays
            .Where(h => h.Country.CountryCode == countryCode && h.Date.Year.ToString() == year);
        return await holidays.ToListAsync();
    }
}