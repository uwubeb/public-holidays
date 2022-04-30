using public_holidays.api.Responses;
using Refit;

namespace public_holidays.api;

public interface IHolidayApi
{
    [Get("/v2.0?action=getSupportedCountries")]
    Task<IReadOnlyList<SupportedCountryResponse>> GetCountriesAsync();
    [Get("/v2.0?action=getHolidaysForCountry&country={countryCode}&year={year}")]
    Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year);
    
}