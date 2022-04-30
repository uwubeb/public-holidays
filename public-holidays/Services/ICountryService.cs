using public_holidays.api.Responses;
using public_holidays.Data.Dtos;
using public_holidays.Data.Models;

namespace public_holidays.Services;

public interface ICountryService
{
    public Task<IReadOnlyList<SupportedCountryResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}
