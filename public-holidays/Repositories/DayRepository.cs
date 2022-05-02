using Microsoft.EntityFrameworkCore;
using public_holidays.Data;
using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public class DayRepository : IDayRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public DayRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool? IsWorkDay(Day day)
    {
        //return if day exists else null
        var exists = _dbContext.Days.Any(d => d.Date == day.Date && d.CountryCode == day.CountryCode);
        if (exists)
        {
            return _dbContext.Days.FirstOrDefault(d => d.Date == day.Date && d.CountryCode == day.CountryCode).IsWorkDay;
        }
        return null;

    }
    public async Task CreateDayAsync(Day day)
    {
        _dbContext.Days.Add(day);
        await _dbContext.SaveChangesAsync();
    }
}