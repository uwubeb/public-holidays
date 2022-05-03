using public_holidays.Data.Models;

namespace public_holidays.Repositories;

public interface ICountryRepository
{
    Task<ICollection<Country>> GetAllAsync(CancellationToken cancellationToken = default);
}