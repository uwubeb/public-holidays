using public_holidays.api.Responses;

namespace public_holidays.Services;

public class HolidayApiService
{
    private readonly HttpClient _httpClient;
    
    public HolidayApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://kayaposoft.com");
    }

    public async Task<IReadOnlyList<HolidaysForCountryResponse>> GetHolidaysForCountryAndYearAsync(string countryCode, string year)
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyList<HolidaysForCountryResponse>>(
        "/enrico/json/v2.0/?action=getHolidaysForYear&year=" + year + "&country=" + countryCode);
    }
    
    public async Task<IReadOnlyList<SupportedCountryResponse>> GetSupportedCountriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IReadOnlyList<SupportedCountryResponse>>(
            "/enrico/json/v2.0/?action=getSupportedCountries");
    }
    
    public async Task<IsPublicHolidayResponse> IsPublicHolidayAsync(string countryCode, string year, string month, string day)
    {
        return await _httpClient.GetFromJsonAsync<IsPublicHolidayResponse>(
            "/enrico/json/v2.0/?action=isPublicHoliday&date=" + day + "-" + month + "-" + year + "&country=" + countryCode);
    }

    public async Task<IsWorkDayResponse> IsWorkDayAsync(string countryCode, string year, string month, string day)
    {
            return await _httpClient.GetFromJsonAsync<IsWorkDayResponse>(
            "/enrico/json/v2.0/?action=isWorkDay&date=" + day + "-" + month + "-" + year + "&country=" + countryCode);
    }


}