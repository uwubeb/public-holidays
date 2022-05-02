using Microsoft.EntityFrameworkCore;
using public_holidays.Data;
using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CountryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<Country>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Countries.Include(x => x.Holidays).ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Country>> CreateMany(ICollection<Country> countries)
    {
        await _dbContext.Countries.AddRangeAsync(countries);
        await _dbContext.SaveChangesAsync();

        return countries;
    }
}