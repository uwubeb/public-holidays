using public_holidays.Data.Responses;

namespace public_holidays.Services;

public class HolidayApiService
{
    private readonly HttpClient _httpClient;
    
    public HolidayApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://kayaposoft.com");
    }

    public async Task<ICollection<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _httpClient.GetFromJsonAsync<ICollection<HolidaysForCountryResponse>>(
        "/enrico/json/v2.0/?action=getHolidaysForYear&year=" + year + "&country=" + countryCode);
    }
    
    public async Task<ICollection<SupportedCountryResponse>> GetSupportedCountriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<SupportedCountryResponse>>(
            "/enrico/json/v2.0/?action=getSupportedCountries");
    }
    


}