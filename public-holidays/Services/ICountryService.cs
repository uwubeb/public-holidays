using public_holidays.Data.Dtos;
using public_holidays.Data.Models;

namespace public_holidays.Services;

public interface ICountryService
{
    public Task<ICollection<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
