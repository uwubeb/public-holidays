using public_holidays.Data.Dtos;

namespace public_holidays.Services;

public interface ICountryService
{
    public Task<ICollection<CountryDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
